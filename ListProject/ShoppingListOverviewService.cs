namespace ListProject;

public class ShoppingListOverviewService
{
    public IShoppingListDataSource DataSource;

    public ShoppingListOverviewService(IShoppingListDataSource dataSource)
    {
        DataSource = dataSource;
    }

    public List<ShoppingList>? GetAllShoppingLists() => 
        DataSource.GetAllShoppingLists();

    public void CreateNewShoppingList(ShoppingList list) => 
        DataSource.CreateShoppingList(list);

    public void DeleteShoppingList(ShoppingList list) => 
        DataSource.DeleteShoppingList(list);

    public ShoppingList SelectShoppingList(int choice) => 
        DataSource.SelectListToView(choice);
    
}