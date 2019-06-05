using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraAtoFinal : MonoBehaviour
{
    public BoxCollider collider;
    [SerializeField] int health;
    [SerializeField] int index = 0;
    public int maxHealth = 3;
    bool hitCooldown;
    public GameObject fx;
    public GameObject fxHit;
    public Vector3 droplocation;
    public Vector3[] tabuaLocation = new Vector3[3];
    public Vector3[] tabuaRotation = new Vector3[3];
    GameObject[] StoredTabua = new GameObject[3];
    public bool stored;

    private void Update()
    {
        if (stored) collider.enabled = true;
        else collider.enabled = false;

        if (index > 0) stored = true; else stored = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OBJ_Tabua" && index < 3)
        {
            //stored = true;
            other.tag = "Untagged";
            StoredTabua[index] = other.gameObject;
            Rigidbody attachedRigidbody = other.GetComponent<Rigidbody>();
            other.transform.parent = this.transform;
            other.transform.position = tabuaLocation[index];
            other.transform.rotation = Quaternion.Euler(tabuaRotation[index]);
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            this.gameObject.tag = "Interactable";
            health = maxHealth;
            index++;
        }

        if (other.gameObject.tag == "Enemy" && stored)
        {
            hitCooldown = true;
            Invoke("ResetCooldown", 2f);
        }
    }

    private void OnMouseOver()
    {
        if(stored && Input.GetButtonDown("Fire1"))
        {
            StoredTabua[index-1].tag = "Pickupable Object";
            Rigidbody attachedRigidbody = StoredTabua[index-1].GetComponent<Rigidbody>();
            StoredTabua[index-1].transform.parent = null;
            attachedRigidbody.isKinematic = false;
            attachedRigidbody.useGravity = true;
            attachedRigidbody.constraints = RigidbodyConstraints.None;
            StoredTabua[index-1].transform.position = droplocation;
            index--;
            //stored = false;
            this.gameObject.tag = "Untagged";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && stored)
        {
            if (!hitCooldown)
            {
                HitaMadeira(StoredTabua[index]);
            }

            if (health == 0)
            {
                QuebraMadeira(StoredTabua[index]);
            }
        }
    }

    void ResetCooldown()
    {
        hitCooldown = false;
    }

    void HitaMadeira(GameObject tabua)
    {
        //Instancia som e efeito
        Instantiate(fxHit, tabua.transform.position, Quaternion.identity);
        //
        health--;
        hitCooldown = true;
        Invoke("ResetCooldown", 2f);
    }

    void QuebraMadeira(GameObject tabua)
    {
        //Instancia som e efeito
        Instantiate(fx, tabua.transform.position, Quaternion.identity);
        //
        health = maxHealth;
        Destroy(tabua);
        index--;
        //stored = false;
    }

}
