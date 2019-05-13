using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPick : MonoBehaviour
{

    public bool isPicked;
    public Transform hand;
    GameObject lastObject;
    PickupableObject objectScript;

    private void Awake()
    {
        lastObject = null;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 7f) && hit.transform.tag == "Interactable")
        {
            Debug.Log("OBjeto detectado");
            //outline brilha
            /*
            lastObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                isPicked = !isPicked;
            }
            */
            lastObject = hit.transform.gameObject;
            hit.transform.gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0.02f);



        }
        else if(lastObject != null)
        {
            //outline nao brilha
            lastObject.transform.gameObject.GetComponent<Renderer>().material.SetFloat("_FirstOutlineWidth", 0f);
        }
        /*
        if (Input.GetKeyDown(KeyCode.E) && isPicked)
        {
            isPicked = false;
        }


        if (isPicked && lastObject != null)
        {
            lastObject.transform.position = hand.transform.position;
            lastObject.transform.rotation = hand.transform.rotation;
            lastObject.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(lastObject != null)
        {
            lastObject.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        */


        if (Physics.Raycast(ray, out hit, 4f))
        {
            if (hit.transform.gameObject.GetComponent<PickupableObject>())
            {
                objectScript = hit.transform.gameObject.GetComponent<PickupableObject>();

                objectScript.isLooking = true;
            }
        }
        else
        {
            if(objectScript != null)
            objectScript.isLooking = false;
        }
    }
}
