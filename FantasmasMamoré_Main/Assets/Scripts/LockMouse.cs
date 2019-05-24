using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (FPSControl.live == true && FPSControl.victory == false && Time.deltaTime == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (FPSControl.victory == false && FPSControl.live == true && Time.deltaTime == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (FPSControl.live == false && FPSControl.victory == false && Time.deltaTime == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (FPSControl.victory == true && FPSControl.live == true && Time.deltaTime == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
