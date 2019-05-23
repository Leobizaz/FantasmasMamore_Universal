using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoMechanics : MonoBehaviour
{

    public bool constructed;

    private bool played;
    private bool fallOff;
    private Animator anim;
    private float velocity = 0.5f;
    [SerializeField] float currentSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    void Update()
    {
        if (constructed && !played)
        {
            played = true;
            anim.Play("TrolleyPrepare");
        }



        currentSpeed = anim.speed;
        if (fallOff)
        {
            anim.speed = Mathf.MoveTowards(anim.speed, 0,  0.8f * Time.deltaTime);
            if (anim.speed <= 0) fallOff = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && constructed)
        {
            fallOff = false;
            anim.speed = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && constructed)
        {
            fallOff = true;
        }
    }
}
