using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    public float pickUpDistance = 3f;

    private ObjectGrabable objectGrabable;


    private void Update()
    {

        //check if pressed "E" while lookin at grabable obj to pick up
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) )
        {
            if (objectGrabable == null) { 
                // not  carrying an obj, try to grab
                
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {

                    if (raycastHit.transform.TryGetComponent(out objectGrabable)) {
                        objectGrabable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabable);
                        objectGrabable.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            } else
            {
                //Carrying object, drop
                objectGrabable.Drop();
                objectGrabable = null;
               // objectGrabable.GetComponent<Rigidbody>().isKinematic = true;
            }
        }



    }
}
