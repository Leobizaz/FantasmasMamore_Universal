using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GIF : MonoBehaviour
{
    public Sprite[] frames;
    Image img;
    [SerializeField] int index;
    float startTime;
    float elapsedTime;

    private void Start()
    {
        img = GetComponent<Image>();
        Time.timeScale = 1;
        startTime = Time.time;
    }

    private void OnGUI()
    {
        elapsedTime = Time.time - startTime;
        index = (int)(elapsedTime * 40 ) / frames.Length;
        if (index >= frames.Length) startTime = elapsedTime;
    }

    private void Update()
    {
        img.sprite = frames[index];
    }
}
