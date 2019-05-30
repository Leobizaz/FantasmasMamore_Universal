using System;
using UnityEngine;
using UnityEngine.Audio;

public class VilaoSounds : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.spatialBlend = 1;
            s.source.minDistance = 3.5f;
            s.source.maxDistance = 15f;
            s.source.volume = VolumeBrightness.Saved_volumeVozes;
            s.source.pitch = s.pitch;
        }
    }

    private void Update()
    {
        foreach(Sound s in sounds)
        {
            s.source.volume = VolumeBrightness.Saved_volumeVozes;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
}
