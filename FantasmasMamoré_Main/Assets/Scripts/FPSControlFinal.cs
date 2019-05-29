using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControlFinal : MonoBehaviour
{
    CharacterController player;
    public GameObject eyes;
    private Rigidbody rb;
    Coroutine lastCoroutine;
    public bool moveLock = false;

    public static bool alive = true;

    public float speed;
    float ForwardBack;
    float LeftRight;
    public float speedfactor;
    public float acceleration;
    AudioSource audio;

    public float sensitivity;
    float camX;
    float camY;
    public bool noMove;

    public float gravity = 100.0f;

    Animator anim;

    public GameObject lamparinasave;

    private void Start()
    {
        Time.timeScale = 1;
        player = this.GetComponent<CharacterController>();
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        speedfactor = 1;
        lastCoroutine = null;
        audio = GetComponent<AudioSource>();
        //moveLock = true;
        player.enabled = false;
        Invoke("Disconnect", 6f);
        Save();
    }

    void FixedUpdate()
    {
        if (moveLock) CameraRun.speed = 0f;

        if (!moveLock)
        {
            ForwardBack = Input.GetAxis("Vertical") * speed;
            LeftRight = Input.GetAxis("Horizontal") * speed;
            Vector3 move = new Vector3(ForwardBack, 0, -LeftRight);
            move = transform.rotation * move;
            move.y = move.y - (gravity * Time.deltaTime);

            camX = Input.GetAxis("Mouse X") * sensitivity;
            camY -= Input.GetAxis("Mouse Y") * sensitivity;

            camY = Mathf.Clamp(camY, -90f, 90f);
            player.Move(move * Time.deltaTime);
            transform.Rotate(0, camX, 0);
            // eyes.transform.Rotate(0, 0, camY); // esse não travava a rotação Y
            eyes.transform.localRotation = Quaternion.Euler(0, 0, -camY);


            Vector3 horizontalVelocity = new Vector3(player.velocity.x, 0, player.velocity.z);

            float horizontalSpeed = horizontalVelocity.magnitude;


            if (Input.GetKey(KeyCode.LeftShift) && horizontalSpeed > 1)
            {
                Run();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || horizontalSpeed < 1)
            {

                CameraRun.speed = 0f;
                lastCoroutine = StartCoroutine("Stoprun");
            }
        }
        
        if (alive == false)
        {
            CameraRun.speed = 0f;
            Stoprun();
        }
    }

    public void Run()
    {
        speed = 7f;
        CameraRun.speed = Mathf.Round(3 * 5);
    }

    IEnumerator Stoprun()
    {
        Debug.Log("Stopping");
        speed = 4f;
        yield return new WaitForSeconds(0.1f);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && !Cheats.invincible)
        {
            anim.SetInteger("State", 1);
            moveLock = true;
            alive = false;
        }

    }

    void TeleportPlayer(float Tx, float Ty, float Tz, float Rx, float Ry, float Rz)
    {
        player.enabled = false;
        transform.localPosition = new Vector3(Tx, Ty, Tz);
        transform.localRotation = Quaternion.Euler(Rx, Ry, Rz);
        player.enabled = true;
    }

    public void Disconnect()
    {
        GetComponent<CutsceneLookControl>().WideScreenInF();
        transform.parent.gameObject.transform.SetParent(null, true);
        //transform.parent.gameObject.transform.localPosition = Vector3.zero;
        //transform.localPosition = Vector3.zero;
        TeleportPlayer(4.52f, -1.54f, 3.79f, 0, 0, 0);

        //moveLock = false;

    }

    public void Save()
    {
        lamparinasave.SetActive(true);
        Invoke("DesativaLamparina", 5f);
    }

    void DesativaLamparina()
    {
        lamparinasave.SetActive(false);
    }
}
