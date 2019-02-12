using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "biomass", "delta", "meteor", "equator", "oasis" };
    string[] level2Passwords = { "populists", "liberalism", "dictatorship", "government", "hierarchy" };
    string[] level3Passwords = { "prepayment", "guarantor", "withdrawal", "deferred payment", "statement" };

    //Game State
    int level;
    string password;

    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;



    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }


    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What system would you like to hack?");
        Terminal.WriteLine("Press 1 for NASA");
        Terminal.WriteLine("Press 2 for US Government");
        Terminal.WriteLine("Press 3 for Bank of America");
        Terminal.WriteLine("Enter your selection:");
    }



    void OnUserInput(string input)
    {
        if (input == "menu")  // we can always go directly to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunGuessPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Access Denied!");
        }
    }

    void RunGuessPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
            //currentScreen = Screen.Win;
        }
        else
        {
            AskForPassword();
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
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
);
                Terminal.WriteLine("Welcome to NASA's internal system!");
                //Terminal.WriteLine("Nasa's recent reports");
                //Terminal.WriteLine("1. Only Upper class american's will live on Mars, while the rest will be left to die on Earth.");
                //Terminal.WriteLine("2. Aliens do exist.");
                //Terminal.WriteLine("3. The Russian's were the first to land on the moon, but we detoryed all evidence.");
                break;

            case 2:
                Terminal.WriteLine(@"
 __  __   __ 
| | | | / __|
| |_| | \__ \
|_____| |___)

"
);
                Terminal.WriteLine("Welcome to the US Govenment's system!");
                //Terminal.WriteLine("Government's recent reports");
                //Terminal.WriteLine("1. We have access to everyone's phone in America");
                //Terminal.WriteLine("2. A chemical breakout will occur March 3, 2019");
                //Terminal.WriteLine("3. We killed Biggie Smalls");
                break;

            case 3:
                Terminal.WriteLine(@"
        ._._._._._._._._._._.
        |o BANK OF AMERICA o| 
        | """""" |  """"""  |  
        |___________________|

"
);
                Terminal.WriteLine("Bank of America's Accounts");
                //Terminal.WriteLine("Account 4567394: $1,000,000");
                //Terminal.WriteLine("Account 209586: $3,600,789,000");
                //Terminal.WriteLine("Account 1234987: $900,126,596,003");
                break;
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Access Denied!");
                break;
        }
    }
}
