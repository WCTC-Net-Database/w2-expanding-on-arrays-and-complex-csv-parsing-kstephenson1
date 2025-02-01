using CsvHelper;
using System.Globalization;
using w2_assignment_ksteph.DataHelper;

namespace w2_assignment_ksteph.Handlers;

// The CharacterHandler class contains methods that manipulate Character data, including displaying, adding, and leveling up characters.

public static class CharacterHandler
{
    public static void DisplayAllCharacters() //Displays each character's Name, 
    {
        Console.Clear();
        string input = "input.csv";

        using StreamReader reader = new(input);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);

        IEnumerable<Character> characters = csv.GetRecords<Character>();

        foreach (Character character in characters)
        {
            DisplayCharacterInfo(character);

            InventoryHandler.ListInventory(character.Inventory);
        }
    }

    public static void NewCharacter()
    {
        string name = Input.GetString("Enter your character's name: ");
        string characterClass = Input.GetString("Enter your character's class: ");
        int level = Input.GetInt("Enter your character's level: ", 1, "must be greater than 0");
        int hitPoints = Input.GetInt("Enter your character's maximum hit points: ", 1, "must be greater than 0");
        string? inventory = Input.GetString("Enter your character's equipment (separate items with a '|'): ", false);

        Console.Clear();
        Console.WriteLine($"\nWelcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", inventory)}.\n");

        string input = "input.csv";
        Character newCharacter = new() { Name = name, CharacterClass = characterClass, Level = level, HitPoints = hitPoints, Inventory = inventory };

        using StreamWriter writer = new(input, true);
        writer.WriteLine(newCharacter);
    }

    public static void LevelUp()
    {
        string levelingCharacterName = Input.GetString("Please enter the name of the character you would like to level up: ");
        Console.Clear();

        string input = "input.csv";
        string output = input;
        int amtLeveled = 0;
        List<Character> outputCharacters = [];

        using (StreamReader reader = new(input))
        using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
        {
            IEnumerable<Character> characters = csv.GetRecords<Character>();

            foreach (Character character in characters)
            {
                if (character.Name == levelingCharacterName)
                {
                    character.Level += 1;
                    amtLeveled += 1;
                }
                outputCharacters.Add(character);
            }
        }

        using StreamWriter writer = new(output);
        using CsvWriter csvOut = new(writer, CultureInfo.InvariantCulture);

        csvOut.WriteRecords(outputCharacters);
        if (amtLeveled > 0)
        {
            Console.WriteLine($"\n{amtLeveled} characters leveled up!\n");
        }
        else
        {
            Console.WriteLine($"No characters with that name found.");
        }
    }

    public static void DisplayCharacterInfo(Character character)
    {
        Console.WriteLine($"{character.Name}  |  Level {character.Level} {character.CharacterClass}  |  HP: {character.HitPoints}");
    }
}
