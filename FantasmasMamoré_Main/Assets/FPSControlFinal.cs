using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControlFinal : MonoBehaviour
{
    CharacterController player;
    public GameObject eyes;
    private Rigidbody rb;
    Coroutine lastCoroutine;
    public bool moveLock = true;

    public static bool alive = true;

    public float speed;
    float ForwardBack;
    float LeftRight;
    public float speedfactor;
    public float acceleration;

    public float sensitivity;
    float camX;
    float camY;
    public bool noMove;

    public float gravity = 100.0f;

    Animator anim;

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
            if (!noMove)
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
        if (col.gameObject.tag == "Enemy")
        {
            anim.SetInteger("State", 1);
            moveLock = true;
            alive = false;
        }

    }
}
