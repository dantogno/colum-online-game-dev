using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private string displayText = "Interactive Object";

    public string DisplayText => displayText;

    public void InteractWith()
    {
        Debug.Log($"The player interacted with {name}");
    }
}
