namespace ListProject;

public class ShoppingListService
{
    public IShoppingListDataSource DataSource;

    public ShoppingListService(IShoppingListDataSource dataSource)
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

    public void AddItem(ShoppingList list, ListItem item)
    {
        list.Items.Add(item);
        DataSource.UpdateShoppingList(list);
    }
    public void RemoveItem(ShoppingList list, ListItem item)
    {
        list.Items.Remove(item);
        DataSource.UpdateShoppingList(list);
    }
    
    
}