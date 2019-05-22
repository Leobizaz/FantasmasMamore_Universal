using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class DialogosGalpao : MonoBehaviour
{
    public AudioClip[] dialogos;
    private AudioSource audio;
    int count;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        count = 0;
        Invoke("PlayNext", audio.clip.length);
    }

    private void Update()
    {

    }

    public void PlayNext()
    {
        if (count - 1 <= dialogos.Length)
        {
            audio.clip = dialogos[count];
            audio.Play();
            count++;
            Invoke("PlayNext", audio.clip.length);
        }
    }

}
