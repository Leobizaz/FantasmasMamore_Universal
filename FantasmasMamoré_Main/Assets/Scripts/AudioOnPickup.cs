using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnPickup : MonoBehaviour
{
    public static bool discovered;
    private AudioSource audio;
    private AudioSource audiodialogo;
    private bool once;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audiodialogo = GameObject.Find("Ato 3/Cenário/Triggers/Trigger_casa").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            if (gameObject.transform.parent.gameObject.name == "hand" && !once && discovered)
            {
                once = true;
                if(!audiodialogo.isPlaying)
                    audio.Play();
            }
        }
    }
}
