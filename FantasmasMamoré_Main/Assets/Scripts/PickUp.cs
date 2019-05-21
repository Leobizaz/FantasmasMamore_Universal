using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject eyes;
    public GameObject hand;
    GameObject grabbedObject;
    float grabbedObjectSize;
    public GameObject handUI;
    public LayerMask myLayerMask;
    public GameObject actualEyes;

    [SerializeField] GameObject grabbedRoot;

    void Start()
    {
        
    }

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = Camera.main.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if(Physics.Linecast(position,target,out raycastHit, myLayerMask))
        {
            return raycastHit.collider.gameObject;
        }

        return null;
    }

    private void OnMouseEnter()
    {
        
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
            Vector3 temp = grabbedObject.transform.position;
            Quaternion temp2 = grabbedObject.transform.rotation;
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            grabbedObject.transform.parent = null;

            //grabbedObject.transform.position = temp;
            //grabbedObject.transform.rotation = temp2;

            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            //grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
         
        }
        grabbedObject = null;
    }

    void LateUpdate()
    {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);

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
            //grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            Quaternion newRotation = Quaternion.Euler(0, -eyes.transform.rotation.y, 0);
            //grabbedObject.transform.rotation = newRotation;

            
            grabbedObject.transform.parent = hand.transform;

            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //grabbedObject.transform.LookAt(this.gameObject.transform);
            

            grabbedObject.transform.right = (grabbedObject.transform.position - transform.position);

            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
            Vector3 newPosition = hand.transform.position;
            //Quaternion newRotation = Quaternion.Euler(0, 0, 0);
            //Camera.main.transform.forward* grabbedObjectSize;
            grabbedObject.transform.position = newPosition;
            //grabbedObject.transform.rotation = newRotation;

        }
    }
}
