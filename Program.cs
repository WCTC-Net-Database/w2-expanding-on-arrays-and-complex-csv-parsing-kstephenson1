namespace w2_assignment_ksteph;

using DataHelper;

class Program
{
    static void Main()
    {
        // Will run until exit is selected
        while (true)
        {
            ShowMenu();
            int selection = Input.GetInt(1, 4, "Value must be between 1-4"); // Uses a helper file to get an int between 1-4 from the user
            if (selection == 4) break; // Exits the program if '4' is selected.
            switch (selection) // Checks the input from the user and responds appropriately.
            {
                case 1:
                    CharacterInfo.DisplayAllCharacters();
                    break;
                case 2:
                    CharacterInfo.NewCharacter();
                    break;
                case 3:
                    CharacterInfo.LevelUp();
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine(
            "\n\n\n\n\n\n\n\n\n" +
            "          ╔═════════════════════════════════════════════════════╗\n" +
            "          ║    Thank you for using the RPG Character Editor.    ║\n" +
            "          ╚═════════════════════════════════════════════════════╝\n" +
            "\n\n\n\n\n\n\n\n\n");
    }

    static void ShowMenu()
    {
        Console.WriteLine(
            "╔═════════════════════════╗\n" +
            "║        Main Menu        ║\n" +
            "╠═════════════════════════╣\n" +
            "║1. Display Characters    ║\n" +
            "║2. New Character         ║\n" +
            "║3. Level Up Character    ║\n" +
            "║4. Exit                  ║\n" +
            "╚═════════════════════════╝\n");
    }
}