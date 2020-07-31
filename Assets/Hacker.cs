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
                int index = Random.Range(0, levelOnePasswords.Length);
                level = 1;
                password = levelOnePasswords[index];
                StartGame();
                break;
            case "2":
                int index2 = Random.Range(0, levelTwoPasswords.Length);
                level = 2;
                password = levelTwoPasswords[index2];
                StartGame();
                break;
            case "3":
                int index3 = Random.Range(0, levelThreePasswords.Length);
                level = 3;
                password = levelThreePasswords[index3];
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
            Terminal.WriteLine("Well done!");
        }
        else
        {
            Terminal.WriteLine("Wrong, try again");
        }
    }
}
