using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuItemTogglePrefab;

    [SerializeField]
    private Transform inventoryListScrollViewContent;

    [SerializeField]
    private TextMeshProUGUI descriptionText, headingText;

    [SerializeField]
    private string defaultHeadingText, defaultDescriptionText;

    private CanvasGroup menuCanvasGroup;
    private PlayerController playerController;
    private DetectInteractiveObjects detectInteractiveObjects;
    private List<InventoryMenuItemToggle> menuItemToggles = new List<InventoryMenuItemToggle>();
    private InventoryMenuItemToggle selectedToggle;
    private AudioSource audioSource;

    public InventoryMenuItemToggle SelectedToggle
    {
        get { return selectedToggle; }
        set
        {
            selectedToggle = value;
            UpdateDescriptionText();
            UpdateHeadingText();
        }
    }



    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
        detectInteractiveObjects = FindObjectOfType<DetectInteractiveObjects>();
        menuCanvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory Menu"))
        {
            audioSource.Play();
            bool isMenuVisible = menuCanvasGroup.alpha > 0;
            if (isMenuVisible)
                HideMenu();
            else
                ShowMenu();
        }
    }

    private void HideMenu()
    {
        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.blocksRaycasts = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        detectInteractiveObjects.enabled = true;
        ClearMenuItemToggles();
    }

    private void ShowMenu()
    {
        menuCanvasGroup.alpha = 1;
        menuCanvasGroup.blocksRaycasts = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = false;
        detectInteractiveObjects.enabled = false;
        GenerateMenuItemToggles();
    }

    private void GenerateMenuItemToggles()
    {
        foreach (InventoryObject item in PlayerInventory.InventoryObjects)
        {
            InventoryMenuItemToggle toggle = 
                Instantiate(menuItemTogglePrefab, inventoryListScrollViewContent).GetComponent<InventoryMenuItemToggle>();
            toggle.AssociatedInventoryObject = item;
            menuItemToggles.Add(toggle);
        }
    }

    private void ClearMenuItemToggles()
    {
        foreach (InventoryMenuItemToggle item in menuItemToggles)
        {
            Destroy(item.gameObject);
        }
        menuItemToggles.Clear();
        SelectedToggle = null;
    }

    private void UpdateDescriptionText()
    {
        if (SelectedToggle != null)
            descriptionText.text = SelectedToggle.AssociatedInventoryObject.DescriptionText;
        else
            descriptionText.text = defaultDescriptionText;
    }

    private void UpdateHeadingText()
    {
        headingText.text = SelectedToggle != null ? SelectedToggle.AssociatedInventoryObject.ObjectName.ToUpper() : defaultHeadingText.ToUpper();
    }
}