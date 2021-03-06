﻿using UnityEditor;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game data
    const string menuHint = "You can type menu at any time!";
    string[] levelOnePasswords = { "books", "aisle", "shelf", "password", "font", "borrow", "shelves" };
    string[] levelTwoPasswords = { "handcuffs", "officer", "guns", "uniform", "station" };
    string[] levelThreePasswords = { "space", "astronaut", "spaceship", "rocket" };
    int lives = 3;


    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

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
        else if(currentScreen == Screen.Password)
        {
            PasswordCheck(input);
        }
    }

    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
                level = 1;
                password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
                AskForPassword();
                break;
            case "2":
                level = 2;
                password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
                AskForPassword();
                break;
            case "3":
                level = 3;
                password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
                AskForPassword();
                break;
            case "1337":
                Terminal.WriteLine("Holy moly you're a 1337 hacker, pls dont h4ck m3");
                break;
            default:
                Terminal.WriteLine("Please choose a valid level");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void PasswordCheck(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            lives--;
            Terminal.WriteLine("Wrong! You have " + lives + " lives left.");
            if(lives == 0)
            {
                lives = 3;
                AskForPassword();
            }
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Welcome to the library!");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /______ //
(_______(/

");
                break;
            case 2:
                Terminal.WriteLine("Welcome to the police office!");
                Terminal.WriteLine(@"
             __@@@___
       _____//_______\______
      |    POLICE           |
      |__ _____________ ____|
         O             O

");
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA. Time to go to...");
                Terminal.WriteLine(@"
  ___ _ __   __ _  ___ ___ 
 / __| '_ \ / _` |/ __/ _ \
 \__ \ |_) | (_| | (_|  __/
 |___/ .__/ \__,_|\___\___|
     |_|                   

");
                break;
            default:
                Debug.LogError("Invalid level!");
                break;
        }
    }
}
