using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectInteractiveObjects : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float detectionDistance = 4.0f;

    [SerializeField]
    private LayerMask detectionLayerMask;

    [SerializeField]
    private TextMeshProUGUI displayText;

    private InteractiveObject lookedAtObject;

    private void Start()
    {
        displayText.text = string.Empty;
    }

    void FixedUpdate()
    {
        UpdateLookedAtObject();
        UpdateDisplayText();
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
        else
        {
            lookedAtObject = null;
        }
    }

    private void UpdateDisplayText()
    {
        if (lookedAtObject != null)
        {
            displayText.text = lookedAtObject.DisplayText;
        }
        else
        {
            displayText.text = string.Empty;
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
