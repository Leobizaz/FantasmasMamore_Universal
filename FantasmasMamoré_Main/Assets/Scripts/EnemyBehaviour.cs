using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    bool barricada;
    public NavMeshAgent agent;
    public GameObject player;

    float extraRotationSpeed;

    void extraRotation()
    {
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);

    }





    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.Find("fantasma").gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.enabled = false;
    }

    void FixedUpdate()
    {
        extraRotation();
        if (GameController_Ato_1.AI_Enabled)
        {
            agent.enabled = true;
            rb.isKinematic = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.enabled = false;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }

        if (rb.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (anim.GetBool("isBashing"))
        {
            agent.enabled = false;
        }
        else if(!anim.GetBool("isBashing") && GameController_Ato_1.AI_Enabled)
        {
            agent.enabled = true;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Barricada")
        {
            barricada = true;
            anim.SetBool("isBashing", true);
        }
        else
        {
            if(!IsInvoking("Test"))
                Invoke("Test", 0.1f);
        }
    }

    void Test()
    {
        barricada = false;
        anim.SetBool("isBashing", false);
    }

}
