using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaBilheteria1 : MonoBehaviour
{
    public Animator anim;
    public BarreiraAtoFinal barreira;

    private void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Enemy" || other.tag == "Player") && !barreira.stored)
        {
            anim.Play("BilheteriaPorta1_Abre");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Enemy" || other.tag == "Player") && !barreira.stored)
        {
            anim.Play("BilheteriaPorta1_Fecha");
        }
    }

    private void Update()
    {
        if (barreira.stored)
        {
            anim.Play("BilheteriaPorta1_Fechada");
        }
    }
}
