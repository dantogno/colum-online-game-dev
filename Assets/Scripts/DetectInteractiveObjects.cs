using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractiveObjects : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float detectionDistance = 4.0f;

    [SerializeField]
    private LayerMask detectionLayerMask;

    private InteractiveObject lookedAtObject;

    void FixedUpdate()
    {
        UpdateLookedAtObject();
    }
    private void Update()
    {
        InteractWithLookedAtObject();
    }

    private void UpdateLookedAtObject()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * detectionDistance, Color.red);
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out raycastHit, detectionDistance, detectionLayerMask))
        {
            Debug.Log("Raycast hit " + raycastHit.collider.gameObject.name + ".");
            lookedAtObject = raycastHit.collider.gameObject.GetComponent<InteractiveObject>();
        }
    }

    private void InteractWithLookedAtObject()
    {
        if (lookedAtObject != null && Input.GetButtonDown("Interact"))
        {
            lookedAtObject.InteractWith();
        }
    }
}
