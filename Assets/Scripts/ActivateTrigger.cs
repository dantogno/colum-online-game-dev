using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public GameObject objectToActivate;

    private void Start()
    {
        // Initially turn the object off so that we can leave it on in the editor view.
        objectToActivate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            objectToActivate.SetActive(true); 
    }
}
