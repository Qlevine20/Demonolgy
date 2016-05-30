﻿using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public GameObject GameMenu;
    public KeyCode menuKey;
    public GameObject LevelsScreen;
    public GameObject ControlsScreen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
        if (GameMenu != null && Input.GetKeyUp(menuKey))
        {
            UpdateMenu(GameMenu);
        }
    }


    public void UpdateMenu(GameObject menu)
    {
        if (LevelsScreen.activeSelf)
        {
            LevelsScreen.SetActive(false);
            menu.SetActive(true);
        }
        else if (ControlsScreen.activeSelf) 
        {
            ControlsScreen.SetActive(false);
            menu.SetActive(true);
        }
        else
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 1.0f;
                if(GameObject.Find("Character"))
                {
                    GameObject Char = GameObject.Find("Character");
                    Char.GetComponent<CharacterBehavior>().enabled = true;
                }
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                if (GameObject.Find("Character")) 
                {
                    GameObject Char = GameObject.Find("Character");
                    Char.GetComponent<CharacterBehavior>().enabled = false;
                }
            }
        }
    }

    public void ExitToMainMenu()
    {
        Application.LoadLevel("Main Menu");
        Time.timeScale = 1.0f;
    }

    public void ToLevelsScreen(GameObject menu)
    {
        menu.SetActive(false);
        LevelsScreen.SetActive(true);

    }
    public void ExitLevelsScreen(GameObject menu)
    {
        UpdateMenu(GameMenu);
    }

    public void ToControlsScreen(GameObject menu) 
    {
        menu.SetActive(false);
        ControlsScreen.SetActive(true);
    }

    public void ExitControlsScreen(GameObject menu) 
    {
        UpdateMenu(GameMenu);
    }
    public void LevelButton(int level)
    {
        Debug.Log("Button Pressed");
        Time.timeScale = 1.0f;
        LevelsScreen.SetActive(false);
        GameMenu.SetActive(false);
        MenuScript.levelNum = level;
        Application.LoadLevel("LoadingScreen");
    }
}
