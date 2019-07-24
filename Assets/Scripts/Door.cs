using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{
    private Animator animator;
    private bool isOpen = false;

    public override string DisplayText
    {
        get
        {
            if (isOpen)
                return $"Close {displayText}";
            else
                return $"Open {displayText}";
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        base.InteractWith();
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }
}
