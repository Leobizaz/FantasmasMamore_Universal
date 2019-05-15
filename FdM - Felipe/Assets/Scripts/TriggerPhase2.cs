using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhase2 : MonoBehaviour
{
    public TutorialController tutorial;
    public GameObject dialogo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            dialogo.SetActive(true);
            tutorial.Phase3();
            Destroy(gameObject);
        }
    }
}
