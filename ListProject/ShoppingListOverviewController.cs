namespace ListProject;

public class ShoppingListOverviewController
{
    private ShoppingListOverviewService _overviewService = new ShoppingListOverviewService(
        new JsonShoppingDataSource(PathHelper.GetFilePath("ShoppingList.json")));

    public ShoppingList SelectListToView()
    {
        var lists = ViewAllShoppingLists();
        if (lists == null)
        {
            return null!;
        }
        var choice = ValidationHelper.ValidateInputForNumberInRange(1, ViewAllShoppingLists().Count);
        return choice == 0 ? null! : _overviewService.SelectShoppingList(choice);
    }
    public ShoppingList CreateNewShoppingList()
    {
        Console.WriteLine("Enter a name for the new list");
        var name = ValidationHelper.ValidateTextInput();
        var list = new ShoppingList(name);
        _overviewService.CreateNewShoppingList(list);
        return list;
    }

    public List<ShoppingList>? ViewAllShoppingLists() => 
        _overviewService.GetAllShoppingLists();
    
    
    public void RemoveList()
    {
        Console.WriteLine("Select a shopping list to delete");
        var list = SelectListToView();
        _overviewService.DeleteShoppingList(list);
        Console.WriteLine("List deleted");
    }
   
}