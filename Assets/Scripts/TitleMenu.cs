﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Used for Main Menu commands and accessibility.
/// </summary>
public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}