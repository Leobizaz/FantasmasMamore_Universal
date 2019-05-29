using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCorpo : MonoBehaviour
{
    bool firstTime;

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

            if(Input.GetButtonDown("Fire1") && firstTime)
            {
                GameObject.Find("Controle_AtoFinal").GetComponent<ControleAtoFinal>().End();
            }




        }
    }
}
