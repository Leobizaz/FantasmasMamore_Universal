using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AjustarVolume : MonoBehaviour
{
    public bool Efeito;
    public bool Voz;
    public bool Musica;

    public AudioSource audiosource;

    float volumeEfeitos;
    float volumeVozes;
    float volumeMusica;

    private void Awake()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSavedVolumeOptions();

        if (Efeito) audiosource.volume = volumeEfeitos;
        if (Voz) audiosource.volume = volumeVozes;
        if (Musica) audiosource.volume = volumeMusica;

    }

    void GetSavedVolumeOptions()
    {
        volumeEfeitos = VolumeBrightness.Saved_volumeEfeitos;
        volumeVozes = VolumeBrightness.Saved_volumeVozes;
        volumeMusica = VolumeBrightness.Saved_volumeMusica;
    }


}
