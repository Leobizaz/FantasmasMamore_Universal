using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAtoFinal : MonoBehaviour
{
    private GameObject vilao;
    private Vilao vilaoScript;
    private Animator vilaoAnimator;
    public GameObject player;
    private FPSControlFinal playerScript;
    public bool pause;
    public GameObject telaPause;
    public GameObject musica;
    public GameObject Forcefield;





    private void Awake()
    {
        vilao = GameObject.Find("Vilao");
        vilaoScript = vilao.GetComponent<Vilao>();
        vilaoAnimator = vilao.GetComponent<Animator>();

        playerScript = player.GetComponent<FPSControlFinal>();
    }

    private void Update()
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
    }

    public void Pause()
    {
        playerScript.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pause = true;
        telaPause.gameObject.SetActive(true);
    }

    public void UnPause()
    {
        playerScript.enabled = true;

        Cursor.visible = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause = false;
        telaPause.gameObject.SetActive(false);
    }


    public void BeginDuelo()
    {
        vilaoAnimator.Play("talkingloop");
        vilaoScript.DiscursoLongo();
        Invoke("BeginChase", 55f);
    }

    public void BeginChase()
    {
        SpawnForceField();
        CancelInvoke("BeginChase");
        vilaoScript.StopDiscurso();
        vilaoAnimator.Play("gesture_agree");
        vilaoScript.TardeDemais();
        Invoke("Walcc", 9f);
    }

    public void SpawnForceField()
    {
        //add efeito aki
        Forcefield.SetActive(true);
    }

    public void Walcc()
    {
        vilaoScript.EnableAI();
        //musica.SetActive(true);
        vilaoAnimator.Play("walking");
    }
}
