namespace ListProject;

public class ShoppingIndividualListController
{
    private readonly ShoppingList _list;
    private readonly ShoppingListIndividualListService _service;

    public ShoppingIndividualListController(ShoppingList list)
    {
        _list = list;
        _service = new ShoppingListIndividualListService(
            new JsonShoppingDataSource(PathHelper.GetFilePath("ShoppingList.json")), list);
    }
    
    public void AddNewItemToList()
    {
        Console.WriteLine("Enter a name for the new item");
        var name = ValidationHelper.ValidateTextInput();
        Console.WriteLine("Enter an amount for the new item");
        var amount = ValidationHelper.ValidateNumberInput();
        var item = new ListItem(name, amount);
        _service.AddItem(item);
    }

    private ListItem SelectListItem()
    {
        var itemIndex = ValidationHelper.ValidateInputForNumberInRange(1, _list.Items.Count);
        return itemIndex <= 0 ? null! : _list.Items[itemIndex - 1];
    }
    
    public void RemoveItem()
    {
        Console.WriteLine("Please select the item you want to delete");
        int i = 1;
        foreach (var item in _list.Items)
        {
            Console.WriteLine($"{i++}) {item.Name}");       
        }
        var itemToDelete = SelectListItem();
        if (itemToDelete== null)
        {
            return;
        }
        _service.DeleteItem(itemToDelete);
    }
    public void MarkAllItemsAsDone()
    {
        foreach (var item in _list.Items)
        {
            item.MarkAsDone();       
        }
    }
    public void MarkItemAsDone()
    {
        var item = SelectListItem();
         _service.ChangeItemToBought(item);
    }
    public void MarkItemAsNotDone()
    {
        var item = SelectListItem();
        _service.ChangeItemToNotBought(item);
    }

    public void DeleteItem()
    {
        var item = SelectListItem();
        _service.DeleteItem(item);
    }

    public void ChangeNameItem()
    {
        var item = SelectListItem();
        var name = ValidationHelper.ValidateTextInput();
        _service.ChangeItemName(item, name);
    }

    public void ChangeAmountItem()
    {
        var item = SelectListItem();
        var name = ValidationHelper.ValidateNumberInput();
        _service.ChangeItemAmount(item, name);
    }
}