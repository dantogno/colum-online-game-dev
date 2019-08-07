using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class InventoryMenu : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private DetectInteractiveObjects detectInteractiveObjects;
    private PlayerController playerController;
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
    }
}
