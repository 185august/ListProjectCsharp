using System.Text.Json.Serialization;

namespace ListProject;

public class ShoppingList
{
    public string Name { get;  }
    [JsonPropertyName("id")]
    public Guid Id { get; }
    public string Date { get; }
    public List<ListItem> Items { get; set; }

    public ShoppingList(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Date = DateTime.Today.ToShortDateString();
        Items = [];
    }

    [JsonConstructor]
    public ShoppingList(string name, Guid id, string date, List<ListItem> items)
    {
        Name = name;
        Id = id;
        Date = date;
        Items = items;
    }

    public override bool Equals(object obj)
    {
        return obj is ShoppingList list && Id == list.Id;
    }
}