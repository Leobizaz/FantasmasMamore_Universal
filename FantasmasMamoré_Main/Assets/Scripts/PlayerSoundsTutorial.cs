﻿using System;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSoundsTutorial : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = VolumeBrightness.Saved_volumeVozes;
            s.source.pitch = s.pitch;
        }    
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.volume = VolumeBrightness.Saved_volumeVozes;
        s.source.Play();
    }


}
