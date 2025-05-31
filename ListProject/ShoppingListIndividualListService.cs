namespace ListProject;

public class ShoppingListIndividualListService
{
    private readonly IShoppingListDataSource _dataSource;
    private readonly ShoppingList _list;

    public ShoppingListIndividualListService(IShoppingListDataSource dataSource, ShoppingList list)
    {
        _dataSource = dataSource;
        _list = list;
    }
    
    public void AddItem(ListItem item)
    {
        _list.Items.Add(item);
        _dataSource.UpdateShoppingList(_list);
    }
    
    public void DeleteItem(ListItem item)
    {
        _list.Items.Remove(item);
        _dataSource.UpdateShoppingList(_list);
    }

    public void ChangeItemName(ListItem item, string newName)
    {
        //_list.Items.Find(i => i.Id == item.Id)?.ChangeName(newName);
        item.ChangeName(newName);
        _dataSource.UpdateShoppingList(_list);
    }

    public void ChangeItemAmount(ListItem item, int newAmount)
    {
       // _list.Items.Find(i => i.Id == item.Id)?.ChangeAmount(newAmount);
       item.ChangeAmount(newAmount);
        _dataSource.UpdateShoppingList(_list);
    }

    public void ChangeItemToBought(ListItem item)
    {
        //_list.Items.Find(i=> i.Id == item.Id)?.MarkAsDone();
        item.MarkAsDone();
        _dataSource.UpdateShoppingList(_list);
    }

    public void ChangeItemToNotBought(ListItem item)
    {
        //_list.Items.Find(i => i.Id == item.Id)?.MarkAsNotDone();
        item.MarkAsNotDone();
        _dataSource.UpdateShoppingList(_list);
    }
}