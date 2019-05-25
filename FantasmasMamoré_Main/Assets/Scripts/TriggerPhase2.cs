using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhase2 : MonoBehaviour
{
    public TutorialController tutorial;
    public GameObject dialogo;

    private void Update()
    {
        if (TabuasTutorial.index == 3)
        {
            dialogo.SetActive(true);
            tutorial.Phase3();
            //Destroy(gameObject);
        }
    }
}

