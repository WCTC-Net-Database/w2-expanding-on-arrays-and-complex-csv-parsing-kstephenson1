﻿namespace w2_assignment_ksteph;

using DataHelper;

class Program
{
    static void Main()
    {
        // Will run until exit is selected
        while (true)
        {
            Interface.MainMenu();

            int selection = Input.GetInt(1, 4, "Value must be between 1-4"); // Uses a helper file to get an int between 1-4 from the user

            if (selection == 4) break; // Exits the program if '4' is selected.

            switch (selection) // Checks the input from the user and responds appropriately.
            {
                case 1:
                    CharacterHandler.DisplayAllCharacters();
                    break;
                case 2:
                    CharacterHandler.NewCharacter();
                    break;
                case 3:
                    CharacterHandler.LevelUp();
                    break;
            }
        }

        Interface.ExitMenu();
    }
}