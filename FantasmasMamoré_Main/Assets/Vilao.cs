using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vilao : MonoBehaviour
{
    VilaoSounds dialogue;
    NavMeshAgent AI;
    LookIfClose lookScript;
    public GameObject player;

    bool chasing;

    private void Awake()
    {
        dialogue = GetComponent<VilaoSounds>();
        AI = GetComponent<NavMeshAgent>();
        lookScript = GetComponent<LookIfClose>();
    }

    private void Update()
    {
        if(chasing)
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
        chasing = true;
    }
}
