using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2_assignment_ksteph;

public class InventoryHandler
{
    public static void ListInventory(string inventory) // Takes the inventory string from the csv file, splits it, and displays the inventory to the user.
    {
        Console.WriteLine($"Inventory:");

        if (inventory == "" || inventory == null)
        {
            Console.WriteLine("    - (Empty)");
        }
        else
        {
            List<Item> items = InventoryHandler.StringToItemList(inventory);

            foreach (Item item in items)
            {
                Console.WriteLine($"    - {item}");
            }

            Console.WriteLine("\n");
        }
    }

    public static string ItemListToString(List<Item> items)
    {
        if (items == null)
            return "";
        else
        {
            string inventory = "";

            foreach (Item item in items)
            {
                if (inventory == "")
                    inventory += item.ToString();
                else
                    inventory += "|" + item.ToString();
            }

            return inventory;
        }
    }

    public static List<Item> StringToItemList(string inventory)
    {
        List<Item> itemList = [];

        string[] items = inventory.Split('|');

        foreach (string item in items)
            itemList.Add(new Item(item));

        return itemList;
    }

    public static bool IsEmpty(string itemsAsString)
    {
        if (itemsAsString == "" || itemsAsString == null)
            return true;
        else
            return false;
    }

    public static bool IsEmpty(List<Item> items)
    {
        if (IsEmpty(ItemListToString(items)))
            return true;
        else
            return false;
    }
}
