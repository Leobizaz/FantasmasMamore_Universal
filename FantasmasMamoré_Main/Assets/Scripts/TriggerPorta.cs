using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPorta : MonoBehaviour
{
    ControleAtoFinal controle;

    private void Awake()
    {
        controle = GameObject.Find("Controle_AtoFinal").GetComponent<ControleAtoFinal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            controle.BeginDuelo();
            Destroy(gameObject);
        }
    }

}
