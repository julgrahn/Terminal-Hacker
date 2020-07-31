using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] levelOnePasswords = { "books", "aisle", "self", "password", "font", "borrow", "shelves" };
    string[] levelTwoPasswords = { "handcuffs", "officer", "guns", "uniform", "station" };
    string[] levelThreePasswords = { "space", "astronaut", "spaceship", "rocket" };

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
                StartGame();
                break;
            case "2":
                level = 2;
                password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
                StartGame();
                break;
            case "3":
                level = 3;
                password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
                StartGame();
                break;
            case "1337":
                Terminal.WriteLine("Holy moly you're a 1337 hacker, pls dont h4ck m3");
                break;
            default:
                Terminal.WriteLine("Please choose a valid level");
                break;
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password: ");

    }

    void PasswordCheck(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Wrong, try again");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Welcome to the library!");
                break;
            case 2:
                Terminal.WriteLine("Welcome to the police office!");
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA. Time to go to space.");
                break;
        }
    }
}
