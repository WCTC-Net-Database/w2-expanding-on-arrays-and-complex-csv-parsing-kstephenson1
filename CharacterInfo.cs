namespace w2_assignment_ksteph;

using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using DataHelper;

public class CharacterInfo
{
    // Properties with Attributes for use with CSVHelper Headers
    [Name("Name")]
    public required string Name { get; set; }

    [Name("Class")]
    public required string CharacterClass { get; set; }

    [Name("Level")]
    public required int Level { get; set; }

    [Name("HP")]
    public required int HitPoints { get; set; }

    [Name("Equipment")]
    public string? Inventory { get; set; }


    public static void DisplayAllCharacters() //Displays each character's Name, 
    {
        Console.Clear();
        string input = "input.csv";

        using StreamReader reader = new(input);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);

        IEnumerable<CharacterInfo> records = csv.GetRecords<CharacterInfo>();

        foreach (CharacterInfo record in records)
        {
            Console.WriteLine($"{record.Name}  |  Level {record.Level} {record.CharacterClass}  |  HP: {record.HitPoints}");

            Console.WriteLine($"Inventory:");
            ListInventory(record.Inventory);
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
        string newCharacter = $"{name},{characterClass},{level},{hitPoints},{inventory}";

        using (StreamWriter writer = new(input, true))
        {
            writer.WriteLine(newCharacter);
        }
    }

    public static void LevelUp()
    {
        string levelingCharacter = Input.GetString("Please enter the name of the character you would like to level up: ");
        Console.Clear();

        string input = "input.csv";
        string output = input;
        int amtLeveled = 0;
        List<CharacterInfo> outputCharacters = new();

        using (StreamReader reader = new(input))
        using (CsvReader csv = new(reader, CultureInfo.InvariantCulture))
        {
            IEnumerable<CharacterInfo> records = csv.GetRecords<CharacterInfo>();

            foreach (CharacterInfo record in records)
            {
                if (record.Name == levelingCharacter)
                {
                    record.Level += 1;
                    amtLeveled += 1;
                }
                outputCharacters.Add(record);
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

    static void ListInventory(string inventory) // Takes the inventory string from the csv file, splits it, and displays the inventory to the user.
    {
        if (inventory == "")
        {
            Console.WriteLine("    - (Empty)");
        }
        else
        {
            string[] items = inventory.Split('|');
            foreach (string item in items)
            {
                Console.WriteLine($"    - {item}");
            }
            Console.WriteLine("\n");
        }
    }
}
