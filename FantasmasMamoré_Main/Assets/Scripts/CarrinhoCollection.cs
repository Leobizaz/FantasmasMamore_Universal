using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrinhoCollection : MonoBehaviour
{
    public static bool playerOnRange;

    public GameObject trolleyMDL;
    public GameObject rodasMDL;
    public bool ready;

    private GameObject carrinho;
    private CarrinhoMechanics carrinhoScript;

    private bool alavanca;
    private bool engrenagem;
    private bool roda;

    private GameObject objAlavanca;
    private GameObject objEngrenagem;
    private GameObject objRoda;

    public GameObject somAlavanca;
    public GameObject somEngrenagem;
    public GameObject somRoda;

    void Start()
    {
        carrinho = transform.parent.gameObject;
        carrinhoScript = carrinho.GetComponent<CarrinhoMechanics>();
    }
    void Update()
    {
        if (alavanca && roda && engrenagem) carrinhoScript.constructed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOnRange = true;
        }


        if (ready)
        {
            if (other.tag == "Pickupable Object" && other.name == "Trolley Alavanca")
            {
                other.tag = "Untagged";
                Invoke("SetPositionAlavanca", 0.1f);
                objAlavanca = other.gameObject;
                other.transform.SetParent(trolleyMDL.transform);
                other.transform.position = new Vector3(-0.001062802f, 0.891f, 2.280899e-06f);
                other.transform.rotation = Quaternion.Euler(0, 0, 0);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<BoxCollider>().enabled = false;
                alavanca = true;
            }

            if (other.tag == "Pickupable Object" && other.name == "Trolley Engrenagem")
            {
                other.tag = "Untagged";
                Invoke("SetPositionEngrenagem", 0.1f);
                objEngrenagem = other.gameObject;
                other.transform.SetParent(trolleyMDL.transform);
                other.transform.position = new Vector3(-0.001062802f, 0.891f, 2.280899e-06f);
                other.transform.rotation = Quaternion.Euler(0, 0, 0);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<BoxCollider>().enabled = false;
                engrenagem = true;
            }

            if (other.tag == "Pickupable Object" && other.name == "Roda8")
            {
                other.tag = "Untagged";
                Invoke("SetPositionRoda", 0.1f);
                objRoda = other.gameObject;
                //other.transform.SetParent(rodasMDL.transform);
                other.transform.position = new Vector3(-0.001062802f, 0.891f, 2.280899e-06f);
                other.transform.rotation = Quaternion.Euler(0, 0, 0);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<BoxCollider>().enabled = false;
                roda = true;
            }
        }

    }

    void SetPositionAlavanca()
    {
        objAlavanca.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0);
        objAlavanca.transform.SetParent(trolleyMDL.transform);
        objAlavanca.transform.localPosition = Vector3.zero;
        objAlavanca.transform.position = objAlavanca.transform.parent.gameObject.transform.position;
        objAlavanca.transform.localPosition = new Vector3(0.00f, 0.876f, -0.011f);
        objAlavanca.transform.localRotation = Quaternion.Euler(0, 0, 0);
        somAlavanca.SetActive(true);
    }

    void SetPositionEngrenagem()
    {
        objEngrenagem.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0);
        objEngrenagem.transform.SetParent(trolleyMDL.transform);
        objEngrenagem.transform.localPosition = Vector3.zero;
        objEngrenagem.transform.position = objEngrenagem.transform.parent.gameObject.transform.position;
        objEngrenagem.transform.localPosition = new Vector3(-0.051f, -0.379f, -0f);
        objEngrenagem.transform.localRotation = Quaternion.Euler(90, 0, 90);
        somEngrenagem.SetActive(true);
    }

    void SetPositionRoda()
    {
        objRoda.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0);
        objRoda.transform.SetParent(rodasMDL.transform);
        objRoda.transform.localPosition = Vector3.zero;
        objRoda.transform.position = objRoda.transform.parent.gameObject.transform.position;
        objRoda.transform.localPosition = new Vector3(1.213f, -0.1462065f, -1.072f);
        objRoda.transform.localRotation = Quaternion.Euler(0, 0, -90);
        somRoda.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOnRange = false;
        }
    }

}
