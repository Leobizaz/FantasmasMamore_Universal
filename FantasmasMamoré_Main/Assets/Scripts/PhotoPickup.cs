using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPickup : MonoBehaviour
{
    public GameObject Tela;
    private AudioSource Audio;

    void Start()
    {
        Audio = Tela.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Tela.SetActive(true);
            Audio.Play();
            Globals.photoscollected++;
            Destroy(gameObject);
        }
    }
}
