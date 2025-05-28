namespace ListProject;

public class ShoppingListController
{
    private ShoppingListService _service = new ShoppingListService(
        new JsonShoppingDataSource(PathHelper.GetFilePath("ShoppingList.json")));

    public ShoppingList SelectListToView()
    {
        var choice = ValidationHelper.ValidateInputForNumberInRange(1, ViewAllShoppingLists().Count);
        return choice == 0 ? new ShoppingList("") : _service.SelectShoppingList(choice);
    }
    public void CreateNewShoppingList()
    {
        Console.WriteLine("Enter a name for the new list");
        var name = ValidationHelper.ValidateTextInput();
        var list = new ShoppingList(name);
        _service.CreateNewShoppingList(list);
        Console.WriteLine(list.Name);
    }

    public List<ShoppingList>? ViewAllShoppingLists() => 
        _service.GetAllShoppingLists();
    
    public void AddNewItemToList(ShoppingList shoppingList)
    {
        Console.WriteLine("Enter a name for the new item");
        var name = ValidationHelper.ValidateTextInput();
        Console.WriteLine("Enter an amount for the new item");
        var amount = ValidationHelper.ValidateNumberInput();
        var item = new ListItem(name, amount);
        _service.AddItem(shoppingList, item);
    }
    
    public void RemoveList()
    {
        var list = SelectListToView();
        _service.DeleteShoppingList(list);
        Console.WriteLine("List deleted");
    }
    public void UpdateItem(ShoppingList list, ListItem item)
    {
        
    }
    
    public void RemoveItem(ShoppingList list)
    {
        Console.WriteLine("Please select the item you want to delete");
        int i = 1;
        foreach (var item in list.Items)
        {
            Console.WriteLine($"{i++}) {item.Name}");       
        }
        var itemIndexToDelete = ValidationHelper.ValidateInputForNumberInRange(1, list.Items.Count);
        var itemToDelete = list.Items[itemIndexToDelete - 1];
        _service.RemoveItem(list, itemToDelete);
    }
    public void MarkAllItemsAsDone(ShoppingList list)
    {
        foreach (var item in list.Items)
        {
            item.MarkAsDone();       
        }
    }
    public void MarkAllItemsAsNotDone(ShoppingList list)
    {
        foreach (var item in list.Items)
        {
            item.MarkAsNotDone();
        }
    }
    public void MarkItemAsDone(ShoppingList list, ListItem item)
    {
        item.MarkAsDone();
    }
    public void MarkItemAsNotDone(ShoppingList list, ListItem item)
    {
        item.MarkAsNotDone();
    }
}