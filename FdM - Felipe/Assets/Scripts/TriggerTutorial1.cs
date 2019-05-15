using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial1 : MonoBehaviour
{
    public TutorialController tutorial;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            tutorial.Phase2();

            Destroy(gameObject);
        }
    }

}
