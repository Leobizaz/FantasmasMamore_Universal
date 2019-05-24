using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falantes : MonoBehaviour
{

    public AudioSource aud;
    public AudioClip impact;

    void Start()
    {
        aud = GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            aud.PlayOneShot(impact,0.01f);
        }
    }

}
