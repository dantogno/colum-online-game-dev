using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : InteractiveObject
{
    [SerializeField]
    private GameObject objectToToggle;

    private new AudioSource audioSource;

    protected override void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void InteractWith()
    {
        base.InteractWith();
        objectToToggle.SetActive(!objectToToggle.activeSelf);
        audioSource.Play();
    }
}
