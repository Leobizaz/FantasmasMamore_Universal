using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Globals.photoscollected++;
            Destroy(gameObject);
        }
    }
}
