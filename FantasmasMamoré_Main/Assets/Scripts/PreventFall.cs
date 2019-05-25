using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventFall : MonoBehaviour
{

    private GameObject playerpos;

    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 30)
        {
            transform.position = playerpos.GetComponentInChildren<Transform>().position;
        }
    }
}
