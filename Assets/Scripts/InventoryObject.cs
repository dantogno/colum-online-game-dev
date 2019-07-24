using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = "Interactive Object";

    public string ObjectName => objectName;

    // TODO: Create inventory object icons
    // TODO: Create inventory object description text

    private new Collider collider;
    private MeshRenderer meshRenderer;

    protected override void Start()
    {
        base.Start();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        collider.enabled = false;
        meshRenderer.enabled = false;
    }
}
