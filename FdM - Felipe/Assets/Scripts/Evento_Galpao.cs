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
    //(-131.939f, 51.94f, 43.45f)
    //(-131.913f, 51.02f, 43.35f)
    //(-131.878f, 50.72f, 43.357f)
    //(-131.818f, 51.22f, 43.376f)
    //(-131.863f, 52.389f, 43.542f)

    // Rotacoes das tabuas na barreira 1
    //(-6.735f, -5.252f, -88.676f)
    //(6.940001f, -4.92f, -88.634f)
    //(0f, -5.085f, -88.644f)
    //(-8.585f, -5.636f, -88.206f)
    //(0f, -3.41f, -88.644f)

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
            other.attachedRigidbody.isKinematic = false;
            other.attachedRigidbody.useGravity = false;
            other.transform.position = position[index];
            other.transform.rotation = rotation[index];
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            index++;
        }

    }
}
