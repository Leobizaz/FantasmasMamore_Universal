using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControleTempoGalpao : MonoBehaviour
{
    public float Timeleft = 100f;
    public GameObject SpawnInimigo;
    public bool Spawn = false;
    public static bool BomDia = false;
    public GameObject dialogoacabo;
    public GameObject musica;
    public GameObject somposchase;
    public GameObject telavitoria;
    public Animator portasAbre;

    public GameObject PortaAto1;
    public GameObject TriggerCamaAto1;
    public GameObject TriggersAto3;
    public GameObject ColisoesAto3;
    public GameObject luzes;

    public GameController_Ato_1 gameController;

    public GameObject[] fantasmas;
    public GameObject deathFX;

    public GameObject chicoF;

    public GameObject dialogo_merda;

    public static float time;
    public ObjetivoGlobal objetivo;

    public GameObject dialogos;
    private DialogosGalpao dialogosScript;

    bool ded;
    bool coiso;
    bool abriu;



    public TOD_Sky sky;
    public TOD_Time skytime;

    public GameObject tobecontinued;
   // public bool bomDia = false;
    // Start is called before the first frame update
    void Start()
    {
        dialogosScript = dialogos.GetComponent<DialogosGalpao>();
    }

    // Update is called once per frame
    void Update()
    {

        time = sky.Cycle.Hour;

        if (Spawn == true)
        {
            //Timeleft -= Time.deltaTime;
            skytime.ProgressTime = true;
            skytime.DayLengthInMinutes = 7.5f;




            if (sky.Cycle.Hour >= 7)
            {
                Timeleft = 0;
                skytime.DayLengthInMinutes = 30;
                if(!ded)
                    DespawnFantasmas();
                dialogoacabo.SetActive(true);
                musica.SetActive(false);
                somposchase.SetActive(true);
                Invoke("Vitorial", 7f);
                gameController.Ato1.SetActive(true);
                ColisoesAto3.SetActive(true);
                gameController.trem.SetActive(false);
                PortaAto1.SetActive(false);
                TriggerCamaAto1.SetActive(false);
                TriggersAto3.SetActive(true);
                chicoF.SetActive(false);
            }
            if(sky.Cycle.Hour >= 12)
            {
                skytime.ProgressTime = false;
                luzes.SetActive(false);
            }

        }
        //print(Timeleft);
    }

    public void StartEvent()
    {
        dialogo_merda.SetActive(true);
        Invoke("EnableDialogos", 6f);
        SpawnInimigo.SetActive(true);
        Spawn = true;
        GameController_Ato_1.AI_Enabled = true;
        //dialogotomaraquefuncione.SetActive(true);
    }

    public void EnableDialogos()
    {
        dialogos.SetActive(true);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Pickupable Object" && !coiso)
        {
            coiso = true;

        }
    }

    void DespawnFantasmas()
    {
        ded = true;

        foreach(GameObject fantasma in fantasmas)
        {
            Instantiate(deathFX, fantasma.transform.position, Quaternion.identity);
        }

        SpawnInimigo.SetActive(false);
    }

    void Vitorial()
    {
        //tobecontinued.SetActive(true);
        //telavitoria.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        if (!abriu)
        {
            GameObject.Find("Player Ato 1").GetComponent<FPSControl>().Save();
            abriu = true;
            Globals.playerProgress = 4;
            portasAbre.Play("open");
            objetivo.AtualizaObjetivo();
            ObjetivoGlobal.Objetivo = "Procurar pelo meu corpo na cabana onde durmo.";
        }
    }
}
