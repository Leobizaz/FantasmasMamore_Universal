using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool pause = false;
    public static int playerProgress = 0;
    public static float photoscollected;

    public GameObject player;
    private FPSControl playerScript;
    private FPSControlTutorial playerScriptTutorial;
    public GameObject TelaPause;

    private void Awake()
    {
        if (player.name == "Player Ato 1")
            playerScript = player.GetComponent<FPSControl>();
        else
            playerScriptTutorial = player.GetComponent<FPSControlTutorial>();
    }

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
        print(Time.timeScale);
    }

    public void PannelOff()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pause = false;
        TelaPause.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (player.name == "Player Ato 1")
            playerScript.enabled = false;
        else
            playerScriptTutorial.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pause = true;
        TelaPause.gameObject.SetActive(true);
    }

    public void UnPause()
    {
        if (player.name == "Player Ato 1")
            playerScript.enabled = true;
        else
            playerScriptTutorial.enabled = true;

        Cursor.visible = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause = false;
        TelaPause.gameObject.SetActive(false);
    }
}
