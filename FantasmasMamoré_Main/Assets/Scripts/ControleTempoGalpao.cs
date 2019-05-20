﻿using System.Collections;
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
    public GameObject dialogotomaraquefuncione;
    public GameObject musica;
    public GameObject somposchase;
    public GameObject telavitoria;

    public GameObject[] fantasmas;
    public GameObject deathFX;
    bool ded;
    bool coiso;



    public TOD_Sky sky;
    public TOD_Time skytime;

    public GameObject tobecontinued;
   // public bool bomDia = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Spawn == true)
        {
            //Timeleft -= Time.deltaTime;

            skytime.ProgressTime = true;





            if(sky.Cycle.Hour >= 7)
            {
                Timeleft = 0;
                skytime.ProgressTime = false;
                if(!ded)
                    DespawnFantasmas();
                dialogoacabo.SetActive(true);
                musica.SetActive(false);
                somposchase.SetActive(true);
                Invoke("Vitorial", 7f);
            }
        }
        print(Timeleft);
    }

    public void StartEvent()
    {
        SpawnInimigo.SetActive(true);
        Spawn = true;
        GameController_Ato_1.AI_Enabled = true;
        //dialogotomaraquefuncione.SetActive(true);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Pickupable Object" && !coiso)
        {
            dialogotomaraquefuncione.SetActive(true);
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
        tobecontinued.SetActive(true);
        telavitoria.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
