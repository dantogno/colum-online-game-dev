using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private string displayText = "Interactive Object";

    // public int AutoProperty { get; set; } = 5;

    //public string LonghandProperty
    //{
    //    get { return longhandPropertyBackingVariable; }
    //    set { longhandPropertyBackingVariable = value; }
    //}

    //private string longhandPropertyBackingVariable;

    public string DisplayText => displayText;
    //{
    //    get { return displayText; }
    //}

    public virtual void InteractWith()
    {
        // Debug.Log("The player interacted with " + name + ".");
        // Example of string interpolation.
        Debug.Log($"The player interacted with {name}.");
    }
}
