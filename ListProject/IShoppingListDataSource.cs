namespace ListProject;

public interface IShoppingListService
{
    ShoppingList GetShoppingList();
    ShoppingList CreateShoppingList(string name);
    void DeleteShoppingList(string id);
    
}