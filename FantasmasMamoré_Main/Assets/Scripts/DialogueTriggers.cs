using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public bool autoDestroy = true;
    public AudioClip audioclip;
    public AudioSource playeraudio;
    private bool once;

    void Start()
    {
        playeraudio = GameObject.Find("Player Ato 1").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !once)
        {
            once = true;
            playeraudio.clip = audioclip;
            playeraudio.Play();
            if(autoDestroy)
                Destroy(gameObject);
        }
    }
}
