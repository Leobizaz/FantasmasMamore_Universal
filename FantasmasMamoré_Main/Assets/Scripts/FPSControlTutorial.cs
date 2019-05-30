using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControlTutorial : MonoBehaviour {

    public bool moveLock = false;

    CharacterController player;
    public GameObject eyes;
    private Rigidbody rb;
    Coroutine lastCoroutine;

    public float speed;
    float ForwardBack;
    float LeftRight;
    public float speedfactor;
    public float acceleration;

    public float sensitivity;
    float camX;
    float camY;

    public float gravity = 100.0f;

    private bool faseTres = false;

    void Awake()
    {
        faseTres = false;
    }

    // Use this for initialization
    void Start () {
        player = this.GetComponent<CharacterController>();
        rb = this.GetComponent<Rigidbody>();
        speedfactor = 1;
        lastCoroutine = null;
	}




    // Update is called once per frame
    void Update()
    {
        if(TabuasTutorial.index == 3)
        {
            faseTres = true;
        }

        sensitivity = VolumeBrightness.Saved_sensibilidade;

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


        if (Input.GetKey(KeyCode.LeftShift) && horizontalSpeed > 1 )
        {
            if(faseTres == false)
            Run();
            //StopCoroutine(lastCoroutine);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || horizontalSpeed < 1 )
        {
            if (faseTres == false)
            {
                CameraRun.speed = 0f;
                lastCoroutine = StartCoroutine("Stoprun");
            }
        }
       if(faseTres == true && horizontalSpeed > 1.5)
        {
            CameraRun.speed = 0f;
            speed = 2.5f;
            CameraRunTutorial.speed = Mathf.Round(1 * 6);
        }
        if (faseTres == true && horizontalSpeed < 1)
        {
            CameraRun.speed = 0f;
            speed = 2.5f;
            CameraRunTutorial.speed = Mathf.Round(1 * 2);
        }
    }

    public void Run()
    {
        //Debug.Log("Running");

        //speedfactor = speedfactor + acceleration;
        //speed = speedfactor * 2f;
        speed = 7f;
        //speedfactor = Mathf.Clamp(speedfactor, 1, 3);
        //if(speedfactor >= 2.4f)
        CameraRun.speed = Mathf.Round(3 * 5);
    }

    IEnumerator Stoprun()
    {
        //while (true)
        //{
        Debug.Log("Stopping");
        //  speedfactor = speedfactor - (acceleration*3);
        //speed = speedfactor * 1.6f;
        //speedfactor = Mathf.Clamp(speedfactor, 1, 3);
        //if (speedfactor == 1)
        //{
        //  StopCoroutine(lastCoroutine);
        speed = 4f;
        //}

        yield return new WaitForSeconds(0.1f);

    }

    public void UnlockMovement()
    {
        moveLock = false;
    }

    public void PlaySound_Tobem()
    {
        GetComponent<PlayerSoundsTutorial>().Play("tobem");
    }

    public void PlaySound_fraco()
    {
        GetComponent<PlayerSoundsTutorial>().Play("fraco");
    }

    public void PlaySound_praja()
    {
        GetComponent<PlayerSoundsTutorial>().Play("praja");
    }




}
