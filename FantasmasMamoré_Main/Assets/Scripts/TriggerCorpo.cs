using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCorpo : MonoBehaviour
{
    public static bool firstTime;
    bool secondTime;

    private void Start()
    {
        firstTime = false;
    }

    private void OnMouseOver()
    {
        if(gameObject.tag == "Interactable")
        {
            if (Input.GetButtonDown("Fire1") && !firstTime)
            {
                firstTime = true;
                GameObject.Find("Controle_AtoFinal").GetComponent<ControleAtoFinal>().BeginChase();
                return;
            }

            if(Input.GetButtonDown("Fire1") && firstTime && !secondTime)
            {
                secondTime = true;
                GameObject.Find("Controle_AtoFinal").GetComponent<ControleAtoFinal>().End();
            }




        }
    }
}
