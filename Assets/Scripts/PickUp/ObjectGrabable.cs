using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    /* const float ySizeGrabbing = 0.002f;
    const float xSizeGrabbing = 0.002f;
    const float xSize2 = 0.055f;
    const float ySize2 = 0.055f; */

    private void Awake()
    {
         objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform= objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        //objectRigidbody.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.layer = LayerMask.NameToLayer("Trash");
        //objectRigidbody.GetComponent<BoxCollider>().size.x = new Vector3(xSizeGrabbing, ySizeGrabbing, collider.size.z);
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        gameObject.layer = LayerMask.NameToLayer("Default");

    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null) {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime* lerpSpeed );
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
