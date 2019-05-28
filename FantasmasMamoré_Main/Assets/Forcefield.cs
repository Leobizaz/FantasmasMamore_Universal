using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public GameObject vilao;
    Renderer renderer;
    SphereCollider collider;
    private Color maxAlpha = new Color(0, 255, 235, 0.2f);
    private Color minAlpha = new Color(0, 255, 235, 0);
    [SerializeField] private Color currentColor;
    [SerializeField] private float distance;
    private float maxDistance = 110f;
    private float minDistance = 8f;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        distance = (transform.position - vilao.transform.position).sqrMagnitude;

        float percent = Mathf.InverseLerp(maxDistance, minDistance, distance);
        float value = 0.2f * percent;
        currentColor = new Color(0, 1, 0.9f, value);
        renderer.material.SetColor("_Color", currentColor);


        if (distance >= 110f)
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }

}
