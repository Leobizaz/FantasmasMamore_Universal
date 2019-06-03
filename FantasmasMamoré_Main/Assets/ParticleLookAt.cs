using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLookAt : MonoBehaviour
{
    private GameObject vilao;

    private void Awake()
    {
        vilao = transform.parent.GetComponent<ForcefieldLink>().vilao;
    }

    private void Update()
    {
        Vector3 position = new Vector3(vilao.transform.position.x, vilao.transform.position.y + 1.3f, vilao.transform.position.z);
        transform.LookAt(position);
    }

}
