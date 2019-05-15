using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC1_Walktoposition : MonoBehaviour
{
    public NavMeshAgent agent;

    private void Start()
    {
        Invoke("Walk", 3.8f);   
    }

    public void Walk()
    {
        agent.SetDestination(new Vector3(-69.7f, 1.05f, 96.8f));
    }
}
