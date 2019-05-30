using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCarrinho : MonoBehaviour
{
    public CarrinhoCollection script;
    public GameObject roda;
    public GameObject alavanca;
    public GameObject engrenagem;

    bool once;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !once)
        {
            once = true;
            AudioOnPickup.discovered = true;
            script.ready = true;

            roda.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.05f);
            alavanca.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.05f);
            engrenagem.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.05f);

        }
    }
}
