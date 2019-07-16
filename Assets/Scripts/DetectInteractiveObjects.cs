using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractiveObjects : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float detectionDistance = 3.0f;

    [SerializeField]
    private LayerMask layersToDetect;

    private InteractiveObject lookedAtObject;

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtObject != null)
        {
            lookedAtObject.InteractWith();
        }
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * detectionDistance, Color.red);
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, 
            out raycastHit, detectionDistance, layersToDetect))
        {
            // The code within this if statement block only executes if our raycast hits something.
            Debug.Log("The raycast hit " + raycastHit.collider.gameObject.name);

             lookedAtObject = 
                raycastHit.collider.gameObject.GetComponent<InteractiveObject>();
        }
    }
}
