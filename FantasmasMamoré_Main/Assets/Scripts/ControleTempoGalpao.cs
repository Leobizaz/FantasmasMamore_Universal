using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
            Timeleft -= Time.deltaTime;
            
            if(Timeleft <= 0)
            {
                Timeleft = 0;
                SpawnInimigo.SetActive(false);
                BomDia = true;
                dialogoacabo.SetActive(true);
                musica.SetActive(false);
                somposchase.SetActive(true);

            }
        }
        print(Timeleft);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            SpawnInimigo.SetActive(true);
            Spawn = true;
            GameController_Ato_1.AI_Enabled = true;
            dialogotomaraquefuncione.SetActive(true);
        }
    }
}
