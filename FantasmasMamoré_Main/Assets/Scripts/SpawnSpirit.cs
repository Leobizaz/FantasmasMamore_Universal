using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpirit : MonoBehaviour
{

    public GameObject obj;

    void OnEnable()
    {
        Invoke("EnableObject", 6f);
    }

    void EnableObject()
    {
        obj.SetActive(true);
    }

}
