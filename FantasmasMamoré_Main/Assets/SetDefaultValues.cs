using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDefaultValues : MonoBehaviour
{
    void Start()
    {
        VolumeBrightness.Saved_brilho = 0.2f;
        VolumeBrightness.Saved_volumeMusica = 0.5f;
        VolumeBrightness.Saved_volumeVozes = 0.5f;
        VolumeBrightness.Saved_volumeEfeitos = 0.2f;

        Invoke("LoadGame", 5f);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
