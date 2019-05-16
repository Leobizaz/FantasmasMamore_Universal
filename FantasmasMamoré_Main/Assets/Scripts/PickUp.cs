using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject eyes;
    GameObject grabbedObject;
    float grabbedObjectSize;
    public GameObject handUI;
    public LayerMask myLayerMask;

    void Start()
    {
        
    }

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if(Physics.Linecast(position,target,out raycastHit, myLayerMask))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        //|| !CanGrab(grabObject)
        if (grabObject == null || !CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    bool CanGrab(GameObject candidate)
    {
        if (candidate.GetComponent<Rigidbody>() != null && candidate.tag == "Pickupable Object")
            return true;
        else
            return false;

    }


    void DropObject()
    {
        if (grabbedObject == null)
            return;

        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            //grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        grabbedObject = null;
    }

    void FixedUpdate()
    {
        if(GetMouseHoverObject(10) != null && GetMouseHoverObject(10).tag == "Pickupable Object")
        {
            handUI.SetActive(true);
        }
        else
        {
            handUI.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(10));
            else
                DropObject();
        }
        if(grabbedObject != null)
            if (grabbedObject.tag != "Pickupable Object") DropObject();

        if(grabbedObject != null)
        {
            /*
                Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
             grabbedObject.transform.position = newPosition;
             grabbedObject.transform.rotation = Quaternion.Euler(-26, grabbedObject.transform.rotation.y, -90);
             //grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
             */

            grabbedObject.transform.parent = eyes.transform;
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPosition;

        }
    }
}
