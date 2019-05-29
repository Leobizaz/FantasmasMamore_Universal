using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjetivosFinal : MonoBehaviour
{
    public TextMeshProUGUI currentObjetivo;
    public string objetivo;
    public Animator popup;

    private void Start()
    {
        Invoke("AtualizaObjetivo", 4f);
    }

    private void Update()
    {
        ObjetivoGlobal.Objetivo = objetivo;  
    }

    public void AtualizaObjetivo()
    {
        popup.Play("Objetivos");
    }

}
