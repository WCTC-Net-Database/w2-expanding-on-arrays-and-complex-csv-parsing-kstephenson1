namespace w2_assignment_ksteph;

// The UserInterface class contains elements for the UI including the main menu and the exit message.
public static class UserInterface
{
    public static void MainMenu()
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

    public static void ExitMenu()
    {
        Console.Clear();
        Console.WriteLine(
            "\n\n\n\n\n\n\n\n\n" +
            "          ╔═════════════════════════════════════════════════════╗\n" +
            "          ║    Thank you for using the RPG Character Editor.    ║\n" +
            "          ╚═════════════════════════════════════════════════════╝\n" +
            "\n\n\n\n\n\n\n\n\n");
    }
}
