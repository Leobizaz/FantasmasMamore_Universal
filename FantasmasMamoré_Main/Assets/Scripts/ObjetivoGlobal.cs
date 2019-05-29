using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjetivoGlobal : MonoBehaviour
{
    public static string Objetivo = "a";
    public TextMeshProUGUI text;
    private Animator popup;

    void Start()
    {
        popup = GetComponent<Animator>();
    }

    void Update()
    {
        text.text = Objetivo;
    }

    public void AtualizaObjetivo()
    {
        popup.Play("Objetivos");
    }

}
