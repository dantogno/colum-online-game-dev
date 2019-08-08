using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [SerializeField]
    private Transform inventoryListScrollViewContent;

    [SerializeField]
    private TextMeshProUGUI descriptionArea, heading;

    [SerializeField]
    private string defaultDescriptionText = "Select an object you have " +
        "collected to view more information about it.";

    [SerializeField]
    private string defaultHeadingText = "Inventory Menu";

    private CanvasGroup canvasGroup;
    private DetectInteractiveObjects detectInteractiveObjects;
    private PlayerController playerController;
    private List<GameObject> menuItemToggles = new List<GameObject>();
    private InventoryMenuItemToggle selectedToggleUseProperty;

    public InventoryMenuItemToggle SelectedToggle
    {
        get { return selectedToggleUseProperty; }
        set
        {
            selectedToggleUseProperty = value;
            UpdateDescriptionText();
            UpdateHeadingText();
        }
    }

    private void Start()
    {
        detectInteractiveObjects = FindObjectOfType<DetectInteractiveObjects>();
        playerController = FindObjectOfType<PlayerController>();
        canvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
        SelectedToggle = null;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory Menu"))
        {
            bool isMenuVisible = canvasGroup.alpha > 0;

            if (isMenuVisible)
                HideMenu();
            else
                ShowMenu();
        }
    }
    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        playerController.enabled = false;
        detectInteractiveObjects.enabled = false;

        GenerateMenuItemToggles();
    }
    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerController.enabled = true;
        detectInteractiveObjects.enabled = true;

        ClearMenuItemToggles();
    }

    private void GenerateMenuItemToggles()
    {
        foreach (InventoryObject inventoryObject in PlayerInventory.InventoryObjects)
        {
            GameObject clone = 
                Instantiate(inventoryMenuItemTogglePrefab, inventoryListScrollViewContent);

            InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
            toggle.AssociatedInventoryObject = inventoryObject;

            menuItemToggles.Add(clone);
        }
    }

    private void ClearMenuItemToggles()
    {
        foreach (GameObject toggle in menuItemToggles)
        {
            Destroy(toggle);
        }
        menuItemToggles.Clear();
        SelectedToggle = null;
    }

    private void UpdateDescriptionText()
    {
        if (SelectedToggle != null)
            descriptionArea.text = SelectedToggle.AssociatedInventoryObject.DescriptionText;
        else
            descriptionArea.text = defaultDescriptionText;
    }

    private void UpdateHeadingText()
    {
        if (SelectedToggle != null)
            heading.text = SelectedToggle.AssociatedInventoryObject.ObjectName.ToUpper();
        else
            heading.text = defaultHeadingText.ToUpper();
    }
}
