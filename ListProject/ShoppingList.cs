namespace ListProject;

public class ShoppingList
{
    public string Name { get;  }
    public string Id { get; }
    public string Date { get; }
    public List<ListItem> Items { get; set; }

    public ShoppingList(string name)
    {
        Name = name;
        Id = Guid.NewGuid().ToString();
        Date = DateTime.Today.ToShortDateString() ;
        Items = [];
    }
}