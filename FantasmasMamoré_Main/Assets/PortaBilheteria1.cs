using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaBilheteria1 : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "Player")
        {
            anim.Play("BilheteriaPorta1_Abre");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
        {
            anim.Play("BilheteriaPorta1_Fecha");
        }
    }
}
