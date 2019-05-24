using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunTutorial : MonoBehaviour
{
    public static float speed = 0f;

    public static float height = 1.6f;

    public static float lado = 0.7f;

    void Update()
    {

        Vector3 pos = transform.localPosition;

        float newY = Mathf.Sin(Time.time * speed);
        float newX = Mathf.Sin(Time.time * speed);
        float newZ = Mathf.Sin(Time.time * speed);

        transform.localPosition = new Vector3(newX, newY, newZ) * height;
       // transform.localPosition = new Vector3(pos.x, pos.y, newX) * lado;
    }
}
