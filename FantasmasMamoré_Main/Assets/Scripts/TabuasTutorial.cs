using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabuasTutorial : MonoBehaviour
{
    [SerializeField]public static int index = 0;

    public Vector3[] position = new Vector3[5];
    public Vector3[] rotationEuler = new Vector3[5];
    Quaternion[] rotation = new Quaternion[5];

    //-91.273   0.008   -5.063
    //-90.713
    //-90.143
    //-89.531
    //-88.894
    //-88.21


    //0 0   0



    void Awake()
    {
        for (int i = 0; i < 5; i++) rotation[i] = Quaternion.Euler(rotationEuler[i]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tabua" && index < 6)
        {
            other.tag = "Untagged";
            other.transform.parent = this.transform;
            other.transform.position = position[index];
            other.transform.rotation = rotation[index];
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            index++;
        }
    }
}
