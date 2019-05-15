using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MulherBehaviour : MonoBehaviour
{
    public Animator anim;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    public void Corre1()
    {
        anim.Play("surprised");
        Invoke("NextPlace1", 3f);
    }
    void NextPlace1()
    {
        agent.SetDestination(new Vector3(-111, 50, 316));
    }

    public void Corre2()
    {
        agent.SetDestination(new Vector3(-120, 52, 229));
    }

    public void Corre3()
    {
        agent.SetDestination(new Vector3(-125, 52, 85));
    }
    public void Corre4()
    {
        agent.SetDestination(new Vector3(-124, 52, 41));
    }
}
