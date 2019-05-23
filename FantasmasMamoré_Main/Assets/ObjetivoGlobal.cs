using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjetivoGlobal : MonoBehaviour
{
    public static string Objetivo = "a";
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Objetivo;
    }
}
