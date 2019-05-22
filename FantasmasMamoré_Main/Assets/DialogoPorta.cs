using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class DialogoPorta : MonoBehaviour
{
    public AudioSource knock;
    public float delay = 2.4f;
    [SerializeField] bool interacted;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1") && !interacted)
        {
            gameObject.tag = "Untagged";
            knock.Play();
            Invoke("PlayAudio", delay);
        }
    }

    void PlayAudio()
    {
        audio.Play();
    }

}
