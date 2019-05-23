using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtualizaObjetivo : MonoBehaviour
{
    public string text;
    public float delay = 0f;
    private bool once;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !once)
        {
            once = true;
            Invoke("DoIt", delay);
        }
    }

    void DoIt()
    {
        ObjetivoGlobal.Objetivo = text;
    }

}
