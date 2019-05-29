using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Animator lembrança;
    public GameObject reply1;
    public GameObject reply2;
    public GameObject voltandoPraCasa;
    public GameObject victoryFx;
    public GameObject jojo;



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
        musica.SetActive(true);
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
        jojo.SetActive(true);
        musica.SetActive(false);
        CancelInvoke("Reply2");
        CancelInvoke("Taunt1");
        CancelInvoke("Taunt2");
        CancelInvoke("Reply1");
        Invoke("EndSequence", 3f);
        Invoke("Lembrança", 5f);
        voltandoPraCasa.SetActive(true);
        Forcefield.SetActive(false);
        Time.timeScale = 0.5f;
        victoryFx.SetActive(true);
        Invoke("FadeOut", 8f);
        Invoke("LoadCredits", 10f);
    }

    public void EndSequence()
    {
        vilaoScript.Defeated();
        GameObject.Find("whiteout").GetComponent<Animator>().Play("whiteout_doit");
    }

    void Lembrança()
    {
        lembrança.Play("lembrança_appear");
    }

    public void FadeOut()
    {
        GameObject.Find("FadeOut").GetComponent<Animator>().Play("FadeOut");
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

}
