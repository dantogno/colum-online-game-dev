using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public void InteractWith()
    {
        Debug.Log($"The player interacted with {name}");
    }
}
