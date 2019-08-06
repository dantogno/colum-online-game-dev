using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;

    private InventoryObject associatedInventoryObject;
    private ToggleGroup toggleGroup;
    private InventoryMenu inventoryMenu;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        inventoryMenu = FindObjectOfType<InventoryMenu>();
        toggleGroup = GetComponentInParent<ToggleGroup>();
        Toggle toggle = GetComponent<Toggle>();
        toggle.group = toggleGroup;
    }
    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    public void OnValueChanged(bool isOn)
    {
        if (isOn)
        {
            inventoryMenu.SelectedToggle = this;
            audioSource.Play();
        }
    }
}
