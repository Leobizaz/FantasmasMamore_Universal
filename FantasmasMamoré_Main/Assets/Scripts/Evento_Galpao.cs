using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_Galpao : MonoBehaviour
{
    [SerializeField] int index = 0;

    public Vector3[] position = new Vector3[5];
    public Vector3[] rotationEuler = new Vector3[5];

    Quaternion[] rotation = new Quaternion[5];

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
    //(-115.5273f, 51.986f, 42.03056f)
    //(-115.5543f, 51.074f, 42.14034f)
    //(-115.59f, 50.466f, 42.215f)
    //(-115.6498f, 50.787f, 42.19544f)
    //(-115.6323f, 51.524f, 42.13258f)

    // Rotacoes das tabuas na barreira 2
    //(-7.2f, -185.784f, -88.633f)
    //(6.940001f, -185.448f, -88.634f)
    //(0f, -185.613f, -88.644f)
    //(-8.585f, -186.163f, -88.206f)
    //(-2.155f, -185.093f, -88.594f)

    void Awake()
    {
        for (int i = 0; i < 5; i++) rotation[i] = Quaternion.Euler(rotationEuler[i]);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "OBJ_Tabua" && index < 5)
        {
            other.tag = "Untagged";
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.transform.position = position[index];
            other.transform.rotation = rotation[index];
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            index++;
        }

    }
}
