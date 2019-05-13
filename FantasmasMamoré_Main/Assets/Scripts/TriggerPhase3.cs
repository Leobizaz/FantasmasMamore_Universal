using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhase3 : MonoBehaviour
{
    public TutorialController tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorial.EndTutorial();
            Destroy(gameObject);
        }
    }

}
