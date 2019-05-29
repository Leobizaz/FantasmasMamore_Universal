using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vilao : MonoBehaviour
{
    VilaoSounds dialogue;
    NavMeshAgent AI;
    LookIfClose lookScript;
    Animator anim;
    public GameObject player;

    bool barricada;
    bool chasing;

    private void Awake()
    {
        dialogue = GetComponent<VilaoSounds>();
        AI = GetComponent<NavMeshAgent>();
        lookScript = transform.parent.GetComponent<LookIfClose>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (chasing)
            AI.SetDestination(player.transform.position);
    }

    public void DiscursoLongo()
    {
        dialogue.Play("DiscursoEntrada");
    }

    public void StopDiscurso()
    {
        dialogue.Stop("DiscursoEntrada");
    }

    public void TardeDemais()
    {
        dialogue.Play("TardeDemais");
    }

    public void Taunt1()
    {
        dialogue.Play("Taunt1");
    }

    public void Taunt2()
    {
        dialogue.Play("Taunt2");
    }

    public void Defeated()
    {
        dialogue.Play("Defeated");
    }

    public void EnableAI()
    {
        //lookScript.enabled = false;
        transform.SetParent(null, true);
        chasing = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Barricada")
        {
            barricada = true;
            anim.SetBool("isBashing", true);
        }
        else
        {
            if (!IsInvoking("Test"))
                Invoke("Test", 0.1f);
        }

    }

    void Test()
    {
        barricada = false;
        anim.SetBool("isBashing", false);
    }
}

