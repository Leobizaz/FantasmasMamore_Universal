using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClamp : MonoBehaviour
{

    Vector3 minPosition;
    Vector3 maxPosition;

    private void Start()
    {
        minPosition = new Vector3(2.3f, 0, 0);
    }

    void FixedUpdate()
    {
        //transform.position = Mathf.Clamp(transform.position, )
    }
}
