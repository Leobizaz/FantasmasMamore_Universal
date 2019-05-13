using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{

    public int playerProgress;

    //playerprogress:
    // 0 = inicio
    // 1 = perseguição
    // 2 = rio

    private void Awake()
    {
        playerProgress = Globals.playerProgress;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            playerProgress = 0;
            Globals.playerProgress = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
            
        }



        playerProgress = Globals.playerProgress;
        Debug.Log(Globals.playerProgress);

    }


}
