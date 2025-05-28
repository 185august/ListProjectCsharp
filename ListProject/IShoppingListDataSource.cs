namespace ListProject;

public interface IShoppingListDataSource
{
    List<ShoppingList>? GetAllShoppingLists();
    void CreateShoppingList(ShoppingList list);
    void DeleteShoppingList(ShoppingList list);
    void UpdateShoppingList(ShoppingList list);
    ShoppingList SelectListToView(int choice);
    void UpdateFile(List<ShoppingList> list);
    

}