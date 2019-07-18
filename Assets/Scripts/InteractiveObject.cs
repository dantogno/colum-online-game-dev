﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected string displayText = "Interactive Object";

    public virtual string DisplayText => displayText;

    protected AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        Debug.Log($"The player interacted with {name}");
        if (audioSource != null)
            audioSource.Play();
    }
}
