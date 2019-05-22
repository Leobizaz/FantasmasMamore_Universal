using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBrightness : MonoBehaviour
{
    public Light ambientLight;
    public Slider sliderBrilho;
    public float brilho;

    public static float Saved_brilho;

    public float volumeEfeitos;
    public float volumeVozes;
    public float volumeMusica;
    public float sensibilidade;

    public Slider sliderEfeitos;
    public Slider sliderVozes;
    public Slider sliderMusica;
    public Slider sliderSensibilidade;

    public static float Saved_volumeEfeitos;
    public static float Saved_volumeVozes;
    public static float Saved_volumeMusica;
    public static float Saved_sensibilidade = 5f;

    private void Awake()
    {
        GetSavedOptions();
    }

    private void Update()
    {
        brilho = sliderBrilho.value;
        ambientLight.intensity = brilho;

        volumeEfeitos = sliderEfeitos.value;
        volumeVozes = sliderVozes.value;
        volumeMusica = sliderMusica.value;
        sensibilidade = sliderSensibilidade.value;

        SetSavedOptions();
    }

    void GetSavedOptions()
    {
        sliderBrilho.value = Saved_brilho;
        sliderEfeitos.value = Saved_volumeEfeitos;
        sliderVozes.value = Saved_volumeVozes;
        sliderMusica.value = Saved_volumeMusica;
        sliderSensibilidade.value = Saved_sensibilidade;
    }

    void SetSavedOptions()
    {
        Saved_brilho = brilho;
        Saved_volumeEfeitos = volumeEfeitos;
        Saved_volumeVozes = volumeVozes;
        Saved_volumeMusica = volumeMusica;
        Saved_sensibilidade = sensibilidade;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
