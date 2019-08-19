using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = "Inventory Object";

    [SerializeField]
    private Sprite icon;

    [TextArea(3, 8)]
    [SerializeField]
    private string descriptionText = "Inventory Object description text goes here.";

    public string ObjectName => objectName;
    public Sprite Icon => icon;
    public string DescriptionText => descriptionText;
    private new Collider collider;
    private MeshRenderer[] meshRenderer;

    protected override void Start()
    {
        base.Start();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentsInChildren<MeshRenderer>();
    }

    

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        Debug.Log($"{objectName} added to inventory.");
        if (collider != null)
            collider.enabled = false;
        if (meshRenderer != null)
        {
            foreach (var renderer in meshRenderer)
            {
                renderer.enabled = false;
            }
        }
    }
}