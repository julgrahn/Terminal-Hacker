﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    void Start()
    {
        ShowGreeting();
    }

    void Update()
    {
        
    }

    void ShowGreeting()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("HACKERMODE ACTIVATED\n");
        Terminal.WriteLine("CHOOSE WHAT TO HACK INTO:");
        Terminal.WriteLine("1. Library");
        Terminal.WriteLine("2. Police");
        Terminal.WriteLine("3. NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowGreeting();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                StartGame();
                break;
            case "2":
                level = 2;
                StartGame();
                break;
            case "3":
                level = 3;
                StartGame();
                break;
            case "1337":
                Terminal.WriteLine("Holy moly you're a leet hacker, pls dont h4ck m3");
                break;
            default:
                Terminal.WriteLine("Please choose a valid level");
                break;
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}