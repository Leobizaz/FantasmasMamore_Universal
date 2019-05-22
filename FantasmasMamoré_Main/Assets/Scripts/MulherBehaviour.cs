using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MulherBehaviour : MonoBehaviour
{
    public bool die;
    public Animator anim;
    private NavMeshAgent agent;
    private AudioSource audio;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (die)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            Invoke("Destroy", 1.5f);
        }
    }

    public void Corre1()
    {
        anim.Play("surprised");
        Invoke("NextPlace1", 1f);
    }
    void NextPlace1()
    {
        audio.Play();
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
        Invoke("GoIdle", 2f);
    }

    public void GoIdle()
    {
        anim.Play("idle");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
