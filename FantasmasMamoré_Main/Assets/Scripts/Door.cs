using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;

    public static bool Cut = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && FPSControl.beliche)
        {
            anim.SetInteger("State", 1);
            Cut = true;
        }
    }
}
