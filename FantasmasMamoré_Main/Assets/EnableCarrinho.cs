using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCarrinho : MonoBehaviour
{
    public CarrinhoCollection script;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioOnPickup.discovered = true;
            script.ready = true;
        }
    }
}
