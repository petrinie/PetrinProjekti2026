using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    public InputActionReference triggeri;

    public GameObject OhjeTeksti;

    public bool grabbing = false;
    bool trigger = false;

    private void Start()
    {
        action.action.Enable();
        triggeri.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        grabbing = action.action.IsPressed();
        trigger = triggeri.action.IsPressed();

        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                grabbedObject.GetComponent<Rigidbody>().useGravity = false;

                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here
                if (otherHand.GetComponent<CustomGrab>().grabbing == false)
                {
                    grabbedObject.position = transform.position;
                    if (!trigger)
                    {
                        grabbedObject.rotation = transform.rotation;
                    } else
                    {
                        grabbedObject.rotation = transform.rotation * transform.rotation;
                    }
                } else
                {
                    Vector3 Keskikohta = (transform.position + otherHand.transform.position) / 2;
                    grabbedObject.position = Keskikohta;
                    if (!trigger)
                    {
                        grabbedObject.rotation = Quaternion.Slerp(transform.rotation, otherHand.transform.rotation, 0.5f);
                    } else
                    {
                        grabbedObject.rotation = Quaternion.Slerp(transform.rotation * transform.rotation, otherHand.transform.rotation * otherHand.transform.rotation, 0.5f);
                    }
                }
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
            if (otherHand.GetComponent<CustomGrab>().grabbing == false) { 
                grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            }
            grabbedObject = null;

        // Should save the current position and rotation here
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if(t && t.tag.ToLower()=="grabbable")
            nearObjects.Add(t);

        OhjeTeksti.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if( t && t.tag.ToLower()=="grabbable")
            nearObjects.Remove(t);
    }
}
