using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [SerializeField]
    private Transform inventoryListScrollViewContent;

    private CanvasGroup canvasGroup;
    private DetectInteractiveObjects detectInteractiveObjects;
    private PlayerController playerController;
    private List<GameObject> menuItemToggles = new List<GameObject>();

    private void Start()
    {
        detectInteractiveObjects = FindObjectOfType<DetectInteractiveObjects>();
        playerController = FindObjectOfType<PlayerController>();
        canvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
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
        foreach (InventoryObject item in PlayerInventory.InventoryObjects)
        {
            GameObject clone = 
                Instantiate(inventoryMenuItemTogglePrefab, inventoryListScrollViewContent);

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
    }
}
