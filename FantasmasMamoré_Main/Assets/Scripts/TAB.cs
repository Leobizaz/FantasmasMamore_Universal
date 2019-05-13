using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAB : MonoBehaviour
{
    public GameObject screen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            screen.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            screen.SetActive(false);
        }
    }
}
