using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : InteractiveObject
{
    [SerializeField]
    private GameObject objectToToggle;

    public override void InteractWith()
    {
        base.InteractWith();
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
