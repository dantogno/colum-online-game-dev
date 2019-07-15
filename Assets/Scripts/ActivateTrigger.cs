using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActivate;

    [SerializeField]
    private bool isReusable = true;

    [SerializeField]
    private bool shouldDeactivateObjectOnStart = true;

    private bool hasBeenUsed = false;

    private void Start()
    {
        // Initially turn the object off so that we can leave it on in the editor view.
        if (objectToActivate != null && shouldDeactivateObjectOnStart)
            objectToActivate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && objectToActivate != null)
        {
            if (!hasBeenUsed || isReusable)
            {
                objectToActivate.SetActive(true);
                hasBeenUsed = true;
            }
        }
    }
}
