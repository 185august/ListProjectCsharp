using System.Text.Json;
using System.Text.Json.Serialization;

namespace ListProject;

public class JsonShoppingDataSource : IShoppingListDataSource
{
    private readonly string _path;

    private JsonSerializerOptions options = new()
    {
        WriteIndented = true,
    };

    public JsonShoppingDataSource(string path)
    {
        _path = path;
    }

    public void UpdateFile(List<ShoppingList> list)
    {
        File.WriteAllText(_path, JsonSerializer.Serialize(list, options));
    }
    private void CheckAndCreateFile()
    {
        var directory = Path.GetDirectoryName(_path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        if (!File.Exists(_path))
            File.WriteAllText(_path, "[]");
    }

    public List<ShoppingList>? GetAllShoppingLists()
    {
        CheckAndCreateFile();
        var json = File.ReadAllText(_path);
        try
        {
            return string.IsNullOrEmpty(json) || json == "[]"
                ? null
                : JsonSerializer.Deserialize<List<ShoppingList>>(json);
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error with JSON: {ex.Message}");
            return new List<ShoppingList>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<ShoppingList>();
        }
    }

    public void CreateShoppingList(ShoppingList list)
    {
        Console.WriteLine($"Using existing id for shopping list: {list.Id}");
        CheckAndCreateFile();
        var existingLists = GetAllShoppingLists() ?? new List<ShoppingList>();
        existingLists.Add(list);
        // File.WriteAllText(_path, JsonSerializer.Serialize(existingLists, options));
        UpdateFile(existingLists);
    }

    public void DeleteShoppingList(ShoppingList list)
    {
        var shoppingLists = GetAllShoppingLists();
        if (shoppingLists == null) return;
        shoppingLists.Remove(list);
        UpdateFile(shoppingLists);
        //File.WriteAllText(_path, JsonSerializer.Serialize(shoppingLists, options));
    }

    public void UpdateShoppingList(ShoppingList list)
    {
        var shoppingLists = GetAllShoppingLists();
        if (shoppingLists == null)
            return;
        foreach (var shoppingList in shoppingLists)
            if (shoppingList.Id == list.Id)
            {
                Console.WriteLine($"Updating list with id {list.Id}");
                shoppingList.Items = list.Items;
            }
            else
            {
                Console.WriteLine($"Skipping list with id {shoppingList.Id}");
            }
        UpdateFile(shoppingLists);
        //File.WriteAllText(_path, JsonSerializer.Serialize(shoppingLists, options));
    }
    

    public ShoppingList SelectListToView(int choice)
    {
        return GetAllShoppingLists()?[choice - 1] ?? new ShoppingList("");
    }
}