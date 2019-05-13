using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialController : MonoBehaviour
{
    //player start position = -119, 1.32 , 166.83

    public GameObject skydome;
    private TOD_Sky sky;
    public GameObject player;
    private FPSControlTutorial playercode;
    public GameObject fade;
    private Animator fadeAnim;
    public Animator objetivo;
    CharacterController controller;

    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject audio_febre;
    public TextMeshProUGUI txtObjetivo;

    public GameObject UI_tutorial_andar;
    public GameObject UI_tutorial_interagir;


    public AudioSource AS_madeira;

    // Start is called before the first frame update
    void Awake()
    {
        controller = player.GetComponent<CharacterController>();
        sky = skydome.GetComponent<TOD_Sky>();
        fadeAnim = fade.GetComponent<Animator>();
        playercode = player.GetComponent<FPSControlTutorial>();
        controller.enabled = false;
        controller.transform.position = new Vector3(-117.77f, 1.49f, 163.41f);
        controller.enabled = true;
        Invoke("PlayerStart", 0.5f);
        Invoke("Phase1", 2f);
    }

    private void Start()
    {
        Cursor.visible = false;
        Invoke("UI_Tutorial_andar", 4f);
        txtObjetivo.text = "Siga o trabalhador até o local de trabalho.";
    }

    public void Phase2()
    {
        //fade out
        fadeAnim.Play("FadeOut");
        txtObjetivo.text = "Buscar uma tábua para o trabalhador que está arrumando o trilho.";
        Invoke("TeleportPlayer_phase2", 2f);
        phase2.SetActive(true);
        UI_tutorial_andar.SetActive(false);
    }

    void TeleportPlayer_phase2()
    {
        controller.enabled = false;
        controller.transform.position = new Vector3(-103f, 1.08f, -8.5f); //Teleporta o jogador
        player.transform.position = new Vector3(-103f, 1.08f, -8.5f);
        controller.enabled = true;
        //sky.Cycle.Hour = 11.18f; //Muda o tempo do dia
        phase1.SetActive(false);
        LoadPhase2(); //Carrega os assets da segunda phase
        fadeAnim.Play("FadeIn");
        Invoke("PlayDialogoMadeira", 1.5f);
        playercode.Invoke("PlaySound_praja", 3.5f);
        Invoke("UI_Tutorial_interagir", 8f);
    }

    void Phase1()
    {
        phase1.SetActive(true);
    }

    public void Phase3()
    {
        playercode.Invoke("PlaySound_Tobem", 1f);
        fadeAnim.Play("FadeOut");
        Invoke("ActualPhase3", 2f);
        UI_tutorial_interagir.SetActive(false);
    }

    void ActualPhase3()
    {
        phase2.SetActive(false);
        phase3.SetActive(true);
        //sky.Cycle.Hour = 17.18f;
        fadeAnim.Play("FadeIn");
        txtObjetivo.text = "Volte para a vila dos trabalhadores pela trilha por onde você veio.";
        Invoke("UpdateObjetivo", 6f);
        controller.enabled = false;
        controller.transform.position = new Vector3(-112.7f, 1.08f, 9.86f); 
        playercode.Invoke("PlaySound_fraco", 2.5f);
        controller.enabled = true;
        Invoke("LoadAudioFebre", 7f);
    }

    void LoadPhase2()
    {
        phase2.SetActive(true);
        phase1.SetActive(false);
    }

    void LoadAudioFebre()
    {
        audio_febre.SetActive(true);
    }

    void PlayDialogoMadeira()
    {
        AS_madeira.Play();
    }

    void UI_Tutorial_andar()
    {
        UI_tutorial_andar.SetActive(true);
    }


    void UI_Tutorial_interagir()
    {
        UpdateObjetivo();
        UI_tutorial_interagir.SetActive(true);
    }

    void UpdateObjetivo()
    {
        objetivo.Play("objetivoatualizado_in");
    }

    IEnumerator Phase3Dialogos()
    {


        StopCoroutine("Phase3Dialogos");
        yield return new WaitForSeconds(2);
    }

    void PlayerStart()
    {
        playercode.enabled = true;
        controller.enabled = false;
        controller.transform.position = new Vector3(-117.77f, 1.49f, 163.41f);
        controller.enabled = true;
    }

    public void EndTutorial()
    {
        fadeAnim.Play("FadeOut");
        Invoke("NextScene", 2f);

    }

    void NextScene()
    {
        SceneManager.LoadScene("Ato 1");
    }

}
