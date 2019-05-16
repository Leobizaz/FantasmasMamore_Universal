using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROckslideSound : MonoBehaviour
{
    public GameObject rockslidesound;
    public GameObject musicStop;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rockslidesound.SetActive(true);
            musicStop.SetActive(true);
        }
    }

}
