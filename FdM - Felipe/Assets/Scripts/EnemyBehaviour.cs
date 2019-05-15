using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
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
        anim = transform.Find("Idle").gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent.enabled = false;
    }

    void Update()
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


    }
}
