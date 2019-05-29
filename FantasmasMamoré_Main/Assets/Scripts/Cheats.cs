using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    public GameObject cheatPanel;
    public static bool invincible;
    bool activePanel;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) { Globals.playerProgress = 0; SceneManager.LoadScene("MenuScene"); }
        if (Input.GetKeyDown(KeyCode.F2)) { Globals.playerProgress = 0; SceneManager.LoadScene("LoadingScreenTutorial"); }
        if (Input.GetKeyDown(KeyCode.F3)) { Globals.playerProgress = 0; SceneManager.LoadScene("LoadingScreenAto1"); }
        if (Input.GetKeyDown(KeyCode.F4)) { Globals.playerProgress = 1; SceneManager.LoadScene("LoadingScreenAto1"); }
        if (Input.GetKeyDown(KeyCode.F5)) { Globals.playerProgress = 2; SceneManager.LoadScene("LoadingScreenAto1"); }
        if (Input.GetKeyDown(KeyCode.F6)) { Globals.playerProgress = 3; SceneManager.LoadScene("LoadingScreenAto1"); }
        if (Input.GetKeyDown(KeyCode.F7)) { Globals.playerProgress = 4; SceneManager.LoadScene("LoadingScreenAto1"); }
        if (Input.GetKeyDown(KeyCode.F8)) { Globals.playerProgress = 5; SceneManager.LoadScene("LoadingScreenAtoFinal"); }
        if( Input.GetKeyDown(KeyCode.F9)) { invincible = !invincible; }
        if( Input.GetKeyDown(KeyCode.F10)) { activePanel = !activePanel; cheatPanel.SetActive(activePanel); }


    }
}
