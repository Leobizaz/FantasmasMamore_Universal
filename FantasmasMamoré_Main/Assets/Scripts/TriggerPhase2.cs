using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhase2 : MonoBehaviour
{
    public TutorialController tutorial;
    public GameObject dialogo;
    public AudioSource taBem;
    public GameObject TaB;


    void Update()
    {
        if (TabuasTutorial.index == 3)
        {
            dialogo.SetActive(true);
            tutorial.Phase3();

                taBem.Play();
                Invoke("Destroy", 7f);
            
            //Destroy(gameObject);
        }
    }
    void Destroy()
    {
        Destroy(TaB);
    }
}

