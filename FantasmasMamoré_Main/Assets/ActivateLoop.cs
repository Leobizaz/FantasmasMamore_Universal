using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLoop : MonoBehaviour
{
    public GameObject loop;
    public AudioSource audio;

    private void Start()
    {
        Invoke("Activate", audio.clip.length);
    }

    void Activate()
    {
        loop.SetActive(true);
    }
}
