using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouseTutorial : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (FPSControl.live == true && FPSControl.victory == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (FPSControl.victory == false && FPSControl.live == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (FPSControl.live == false && FPSControl.victory == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (FPSControl.victory == true && FPSControl.live == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
