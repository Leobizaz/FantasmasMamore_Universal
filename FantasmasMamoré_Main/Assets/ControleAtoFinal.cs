using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAtoFinal : MonoBehaviour
{
    private GameObject vilao;
    private Vilao vilaoScript;
    private Animator vilaoAnimator;
    public Animator portaMeio;
    public GameObject player;
    private FPSControlFinal playerScript;
    public bool pause;
    public GameObject telaPause;
    public GameObject musica;
    public GameObject Forcefield;

    public GameObject reply1;
    public GameObject reply2;
    public GameObject voltandoPraCasa;



    private void Awake()
    {
        GameObject.Find("FadeOut").GetComponent<Animator>().Play("FadeIn");
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
        portaMeio.Play("PortaMeio_Fecha");
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
        Invoke("Taunt1", 8f);
        Invoke("Taunt2", 20f);
    }

    public void Taunt1()
    {
        vilaoScript.Taunt1();
        Invoke("Reply1", 6f);
    }

    public void Taunt2()
    {
        reply2.SetActive(true);
        Invoke("Reply2", 10f);
    }

    void Reply2()
    {
        vilaoScript.Taunt2();
    }


    void Reply1()
    {
        reply1.SetActive(true);
    }

    public void End()
    {
        vilaoScript.Defeated();
        voltandoPraCasa.SetActive(true);
        Forcefield.SetActive(false);
        //fx
        Time.timeScale = 0.5f;
    }

}
