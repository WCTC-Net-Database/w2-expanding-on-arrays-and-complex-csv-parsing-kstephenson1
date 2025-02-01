namespace w2_assignment_ksteph;

using CsvHelper.Configuration.Attributes;

// The Character class is used to store the character information while the csv is being read and written.
public class Character
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
    public required string? Inventory { get; set; }

    public Character() { }

    public override string ToString()
    {
        return $"{Name},{CharacterClass},{Level},{HitPoints},{Inventory}";
    }
}
