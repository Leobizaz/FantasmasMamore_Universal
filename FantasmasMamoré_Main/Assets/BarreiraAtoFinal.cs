using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraAtoFinal : MonoBehaviour
{
    public BoxCollider collider;
    [SerializeField] int health;
    public int maxHealth = 3;
    bool hitCooldown;
    public GameObject fx;
    public GameObject fxHit;
    public Vector3 droplocation;
    public Vector3 tabuaLocation;
    public Vector3 tabuaRotation;
    GameObject StoredTabua;
    bool stored;

    private void Update()
    {
        if (stored) collider.enabled = true;
        else collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OBJ_Tabua" && !stored)
        {
            stored = true;
            other.tag = "Untagged";
            StoredTabua = other.gameObject;
            Rigidbody attachedRigidbody = other.GetComponent<Rigidbody>();
            other.transform.parent = this.transform;
            other.transform.position = tabuaLocation;
            other.transform.rotation = Quaternion.Euler(tabuaRotation);
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            this.gameObject.tag = "Interactable";
            health = maxHealth;
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
            StoredTabua.tag = "Pickupable Object";
            Rigidbody attachedRigidbody = StoredTabua.GetComponent<Rigidbody>();
            StoredTabua.transform.parent = null;
            attachedRigidbody.isKinematic = false;
            attachedRigidbody.useGravity = true;
            attachedRigidbody.constraints = RigidbodyConstraints.None;
            StoredTabua.transform.position = droplocation;
            stored = false;
            this.gameObject.tag = "Untagged";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && stored)
        {
            if (!hitCooldown)
            {
                HitaMadeira(StoredTabua);
            }

            if (health == 0)
            {
                QuebraMadeira(StoredTabua);
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
        //Instantiate(fxHit, tabua.transform.position, Quaternion.identity);
        //
        health--;
        hitCooldown = true;
        Invoke("ResetCooldown", 2f);
    }

    void QuebraMadeira(GameObject tabua)
    {
        //Instancia som e efeito
        //Instantiate(fx, tabua.transform.position, Quaternion.identity);
        //
        health = maxHealth;
        Destroy(tabua);
        stored = false;
    }

}
