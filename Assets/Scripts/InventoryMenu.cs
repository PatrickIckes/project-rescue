﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [Tooltip("The content of the scrollview for the list of inventory items.")]
    [SerializeField]
    private Transform inventoryListContentArea;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private AudioSource audioSource;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instance, but you are trying to access it! Make sure the InventoryMenu script is applied to a GameObject in your scene!");
            return instance;
        }
        private set { instance = value; }
    }

    private bool IsVisible => canvasGroup.alpha > 0;

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }
    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
        
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
        audioSource.Play();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Show Inventory Menu"))
        {
            if (IsVisible)
                HideMenu();
            else
                ShowMenu();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMenu and there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    private void Start()
    {
        
        HideMenu();
        
        StartCoroutine(WaitForAudioClip());
    }

    private IEnumerator WaitForAudioClip()
    {
        audioSource.volume = 0;
        Debug.Log("Start Waiting");
        yield return new WaitForSeconds(audioSource.clip.length);
        Debug.Log("Done Waiting");
        audioSource.volume = 1;
    }
}