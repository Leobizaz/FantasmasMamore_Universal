using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Game Controller").GetComponent<GameController_Ato_1>().PlayNextDialogue();
        }

        Destroy(gameObject);
    }
}
