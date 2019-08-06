using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class InventoryMenu : MonoBehaviour
{
    private CanvasGroup menuCanvasGroup;
    private PlayerController playerController;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        menuCanvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory Menu"))
        {
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
    }

    private void ShowMenu()
    {
        menuCanvasGroup.alpha = 1;
        menuCanvasGroup.blocksRaycasts = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = false;
    }
}