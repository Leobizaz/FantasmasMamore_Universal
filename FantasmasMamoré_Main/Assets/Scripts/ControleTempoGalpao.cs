using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTempoGalpao : MonoBehaviour
{
    public float Timeleft = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timeleft -= Time.deltaTime;
    }
}
