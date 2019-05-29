using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public GameObject telaPause;
    public Animator anim;
    bool paused;


    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
        if (Input.GetKey(KeyCode.Space) && !paused) anim.speed = 4f;
        if (Input.GetKeyUp(KeyCode.Space) && !paused) anim.speed = 1f;
    }

    public void Pause()
    {
        paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;
        telaPause.gameObject.SetActive(true);
    }

    public void UnPause()
    {
        paused = false;
        Cursor.visible = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        telaPause.gameObject.SetActive(false);
    }
}
