using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDefaultValues : MonoBehaviour
{

    public GameObject intro;
    void Start()
    {
        VolumeBrightness.Saved_brilho = 0.2f;
        VolumeBrightness.Saved_volumeMusica = 0.5f;
        VolumeBrightness.Saved_volumeVozes = 0.5f;
        VolumeBrightness.Saved_volumeEfeitos = 0.2f;
        QualitySettings.SetQualityLevel(3);
        Invoke("LoadIntro", 5f);
        Invoke("LoadGame", 12f);
    }

    void LoadIntro()
    {
        intro.SetActive(true);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
