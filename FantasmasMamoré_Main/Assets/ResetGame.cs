using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Reset()
    {
        Globals.playerProgress = 0;
        Globals.photoscollected = 0;
        SceneManager.LoadScene("MenuScene");
    }
}
