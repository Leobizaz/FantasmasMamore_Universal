using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControleTempoGalpao : MonoBehaviour
{
    public float Timeleft = 10f;
    public GameObject SpawnInimigo;
    public bool Spawn = false;
    public static bool BomDia = false; 
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

        }
    }
}
