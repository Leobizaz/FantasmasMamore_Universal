using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FechaGalpao : MonoBehaviour
{
    bool ativo;
    public GameObject porta;
    private AudioSource Au;
    public AudioClip inpact;
    public AudioSource audiomulher;
    public MulherBehaviour codigomulher;
    public GameObject E;
    public GameObject dialogotabua;
    public GameObject musica;
    public ObjetivoGlobal objetivo;

    public ControleTempoGalpao xisde;

    // Start is called before the first frame update
    void Start()
    {
         Au = porta.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && !ativo)
        {
            objetivo.AtualizaObjetivo();
            ObjetivoGlobal.Objetivo = "Posso tentar usar as tábuas soltas por aqui para não deixar essas maldições entrarem...";
            musica.SetActive(true);
            ativo = true;
            porta.transform.rotation = Quaternion.Euler(0, 84.815f, 0);
            //FPSControl.Objetivo.text = "Utilize as tábuas de madeira para bloquear os fantasmas.";
            //E.SetActive(true);
            Au.PlayOneShot(inpact, 0.4f);
            Invoke("Cu", 6f);
            //Destroy(this.gameObject);
            Invoke("AudioMulher", 1f);
            Invoke("KillMulher", 2.5f);
            Invoke("Xisde", 3f);
            Globals.playerProgress = 3;
        }
    }

    void AudioMulher()
    {
        audiomulher.Play();
    }

    void Cu()
    {
        E.SetActive(true);
        dialogotabua.SetActive(true);
        Destroy(this.gameObject);
    }

    void Xisde()
    {
        xisde.StartEvent();
    }

    void KillMulher()
    {
        codigomulher.die = true;
    }
}
