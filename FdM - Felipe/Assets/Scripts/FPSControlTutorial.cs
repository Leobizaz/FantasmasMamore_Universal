﻿using System.Collections;
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


    // Use this for initialization
    void Start () {
        player = this.GetComponent<CharacterController>();
        rb = this.GetComponent<Rigidbody>();
        speedfactor = 1;
        lastCoroutine = null;
        player.transform.position = new Vector3(-110f, 1.38f, 166f);
	}
	
	// Update is called once per frame
	void Update () {

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



            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run();
                StopCoroutine(lastCoroutine);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                CameraRun.speed = 0f;
                lastCoroutine = StartCoroutine("Stoprun");
            }

        
    }

    public void Run()
    {
        Debug.Log("Running");
        
        speedfactor = speedfactor + acceleration;
        speed = speedfactor * 2f;
        speedfactor = Mathf.Clamp(speedfactor, 1, 3);
        if(speedfactor >= 2.4f)
        CameraRun.speed = Mathf.Round(speedfactor * 5);
    }

    IEnumerator Stoprun()
    {
        while (true)
        {
            Debug.Log("Stopping");
            speedfactor = speedfactor - (acceleration*3);
            speed = speedfactor * 1.6f;
            speedfactor = Mathf.Clamp(speedfactor, 1, 3);
            if (speedfactor == 1)
            {
                StopCoroutine(lastCoroutine);
                speed = 2.4f;
            }

            yield return new WaitForSeconds(0.1f);
        }
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