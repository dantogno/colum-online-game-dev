using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : InteractiveObject
{
    [SerializeField]
    private GameObject objectToToggle;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void InteractWith()
    {
        base.InteractWith();
        audioSource.Play();
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }

}
