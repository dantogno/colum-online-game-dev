using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = "Interactive Object";

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    [TextArea(3,8)]
    private string descriptionText;

    private new Collider collider;
    private MeshRenderer meshRenderer;

    public string ObjectName => objectName;
    public Sprite Icon => icon;
    public string DescriptionText => descriptionText;

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
