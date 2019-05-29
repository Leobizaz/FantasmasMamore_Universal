using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefieldLink : MonoBehaviour
{

    public GameObject vilao;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPosition(0, new Vector3(38.96f, 1.52607f, 2.15f));
        Vector3 position = new Vector3(vilao.transform.position.x, vilao.transform.position.y + 1.3f, vilao.transform.position.z);
        line.SetPosition(1, position);
    }
}
