using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulherTrigger : MonoBehaviour
{
    public MulherBehaviour code;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            code.Corre1();
            Destroy(gameObject);
        }
    }
}
