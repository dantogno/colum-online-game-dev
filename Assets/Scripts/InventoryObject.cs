using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = "Inventory Object";

    public string ObjectName => objectName;

    private new Collider collider;
    private MeshRenderer meshRenderer;

    protected override void Start()
    {
        base.Start();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // TODO: create description text
    // TODO: create icon

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        Debug.Log($"{objectName} added to inventory.");
        if (collider != null)
            collider.enabled = false;
        if (meshRenderer != null)
            meshRenderer.enabled = false;
    }
}