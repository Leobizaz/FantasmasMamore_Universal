using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRun : MonoBehaviour
{

    public static float speed = 0f;

    public static float height = 0.15f;

    void Update()
    {

        Vector3 pos = transform.localPosition;

        float newY = Mathf.Sin(Time.time * speed);

        transform.localPosition = new Vector3(pos.x, newY, pos.z) * height;
    }
}
