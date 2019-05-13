using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, transform.rotation.y + rotationSpeed, 0));
    }
}
