using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBaseAttribute]
public class Door : InteractiveObject
{
    [SerializeField]
    private InventoryObject key;

    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip openClip, closeClip, lockedClip;

    private Animator animator;
    private bool isLocked = false;
    private bool isOpen = false;

    public override string DisplayText
    {
        get
        {
            if (isLocked)
            {
                if (!HasKey)
                    return lockedDisplayText;
                else
                    return $"Use {key.ObjectName}";
            }
            if (isOpen)
                return $"Close {displayText}";
            else
                return $"Open {displayText}";
        }
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
        if (isLocked && !HasKey)
        {
            animator.SetTrigger("playShake");
            audioSource.clip = lockedClip;
        }
        else
        {
            if (isLocked && HasKey)
                isLocked = false;

            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);

            if (isOpen)
                audioSource.clip = openClip;
            else
                audioSource.clip = closeClip;
            // the line below is exactly the same functionality, just shorter
            // audioSource.clip = isOpen ? openClip : closeClip;
        }

        base.InteractWith();
    }
}
