using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController_Ato_1 : MonoBehaviour
{
    public static int dialogueIndex;
    public static bool AI_Enabled;

    public GameObject enemyBatch_1;
    public GameObject DeathPanel;
    public GameObject Victory;
    public GameObject Ato1;
    public GameObject Ato2;

    public string level;

    private void Awake()
    {
        AI_Enabled = false;
        dialogueIndex = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void PlayNextDialogue()
    {
        int index = dialogueIndex;
        switch (index)
        {
            case 0:
                PlayFala(null, 1f, "Primeira msg");
                break;
            case 1:
                //PlayFala(audio, tempo)
                PlayFala(null, 6f, "Eita porra um trem fantasma com asas");
                break;
            case 2:
                //PlayFala
                PlayFala(null, 3f, "Eu sou o dam sujão");
                break;
            case 3:
                //PlayFala
                PlayFala(null, 3f, "Olha aki vo spawnar minion");
                enemyBatch_1.SetActive(true);
                
                break;
            case 4:
                PlayFala(null, 26f, "ACHO BOM TU CORRER EM");
                break;
            case 5:
                //AI_Enabled = true;
                break;

        }

        dialogueIndex++;

    }

    void Update()
    {
        if (FPSControl.live == false)
        {
            Death();
        }
        if(FPSControl.victory == true)
        {
            V();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Globals.playerProgress = 0;
            SceneManager.LoadScene("LoadingScreenAto1");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Globals.playerProgress = 1;
            SceneManager.LoadScene("LoadingScreenAto1");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Globals.playerProgress = 2;
            SceneManager.LoadScene("LoadingScreenAto1");
        }

    }

    public void AI_Enable()
    {
        AI_Enabled = true;
    }

    void PlayFala(AudioClip audio, float tempo, string legenda)
    {
        //toca o audio
        Debug.Log(legenda);
        Invoke("PlayNextDialogue", tempo); //toca o próximo
    }

    void Death()
    {
      
            DeathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        

    }
    void V()
    {
        Victory.SetActive(true);
    }

    public void LoadAct1()
    {
        SceneManager.LoadScene(level);
        FPSControl.live = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");

    }

    public void Exit()
    {
        Application.Quit();
    }
}
