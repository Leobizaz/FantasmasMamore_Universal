using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_Galpao : MonoBehaviour
{
    [SerializeField] int index = 0;

    public Vector3[] position = new Vector3[5];
    public Vector3[] rotationEuler = new Vector3[5];

    Quaternion[] rotation = new Quaternion[5];

    [SerializeField] int health;
    public int maxHealth = 3;
    bool hitCooldown;

    public BoxCollider collider;

    public GameObject fx;
    public GameObject fxHit;

    [SerializeField]
    GameObject[] StoredTabua = new GameObject[5];

    // Posicoes das tabuas na barreira 1
    //(-115.53, 52.03, 41.98)
    //(-115.53, 51.12, 41.98)
    //(-115.53, 50.42, 41.98)
    //(-115.571, 50.54, 41.98)
    //(-115.567, 51.53, 41.98)

    // Rotacoes das tabuas na barreira 1
    //(11.715, -5.229, 89.65)
    //(-1.9, -5.122, 90.885)
    //(5.424, -5.143, 90.228)
    //(-8.637, -3.498, 91.495)
    //(3.142, -7.389, 86.13)

    // Posicoes das tabuas na barreira 2
    //(-115.5273f, 51.986f, 42.03056f) | -131.977   51.81   43.595
    //(-115.5543f, 51.074f, 42.14034f) | -131.965   52.484  43.505
    //(-115.59f, 50.466f, 42.215f)  | -131.938  51.163  43.497
    //(-115.6498f, 50.787f, 42.19544f) | -131.923   50.584  43.463
    //(-115.6323f, 51.524f, 42.13258f)  | -131.882  51.467  43.474

    // Rotacoes das tabuas na barreira 2
    //(-7.2f, -185.784f, -88.633f)            |   0 -186.9  90
    //(6.940001f, -185.448f, -88.634f) | 9.52   -185.871    88.85
    //(0f, -185.613f, -88.644f) |  -3.449   -185.613    88.866
    //(-8.585f, -186.163f, -88.206f) |  0.664   -185.694    88.868
    //(-2.155f, -185.093f, -88.594f) |  -37.674 -184.806    88.569
     
    void Awake()
    {
        for (int i = 0; i < 5; i++) rotation[i] = Quaternion.Euler(rotationEuler[i]);
    }
    void Update()
    {
        if (index > 0)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "OBJ_Tabua" && index < 5)
        {
            other.tag = "Untagged";
            StoredTabua[index] = other.gameObject;
            other.transform.parent = this.transform;
            other.transform.position = position[index];
            other.transform.rotation = rotation[index];
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            index++;
            health = maxHealth;
        }

        if(other.gameObject.tag == "Enemy" && index > 0)
        {
            hitCooldown = true;
            Invoke("ResetCooldown", 2f);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && index > 0)
        {
            if (!hitCooldown)
            {
                HitaMadeira(StoredTabua[index - 1]);
            }

            if (health == 0)
            {
                QuebraMadeira(StoredTabua[index - 1]);
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
    }
}
