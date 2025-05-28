using ListProject;

DisplayMainMenu();
return;

void DisplayMainMenu()
{
    Console.WriteLine("Welcome to the list project\nPlease select an option:");
    Console.WriteLine("""
                      1) Go to Shopping lists section 
                      2) Exit program
                      """);
    var userInput = ValidationHelper.ValidateInputForNumberInRange(1, 2);
    switch (userInput)
    {
        case 1:
            DisplayListSection();
            break;
        case 2:
            Environment.Exit(0);
            break;
    }
}

void DisplayListSection()
{
    while (true)
    {
        var controller = new ShoppingListController();
        Console.Clear();
        Console.WriteLine("List section\nPlease select one of the following options:");
        Console.WriteLine("""
                          1) Select a shopping lists to open
                          2) Add a new shopping list
                          3) Delete a shopping list
                          4) Go back to main menu
                          """);
        var userInput = ValidationHelper.ValidateInputForNumberInRange(1, 4);
        switch (userInput)
        {
            case 1:
                ViewShoppingLists(controller);
                var list = controller.SelectListToView();
                ViewIndivudalList(list, controller);
                break;
            case 2:
                controller.CreateNewShoppingList();
                break;
            case 3:
                controller.RemoveList();
                break;
            case 4:
                DisplayMainMenu();
                return;
        }
    }
}

void ViewShoppingLists(ShoppingListController controller)
{
    var lists = controller.ViewAllShoppingLists();
    if (lists != null && lists.Any())
    {
        for (int i = 0; i < lists.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {lists[i].Name}");
        }
    }
    else
    {
        Console.WriteLine("You have no shopping lists");
        Console.WriteLine("Do you want to create a new list? (y/n)");
        var input = ValidationHelper.ValidateYesOrNo();
        if (input == "y")
        {
            controller.CreateNewShoppingList();
        }
    }
}

void ViewIndivudalList(ShoppingList list, ShoppingListController controller)
{
    while (true)
    {
        Console.WriteLine(list.Name);
        if (list.Items.Count == 0)
        {
            Console.WriteLine("The list is empty");
        }
        else
        {
            foreach (var item in list.Items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        Console.WriteLine("\nPlease select one of the following options:");
        Console.WriteLine("""
                          1) Add a new item to the list
                          2) Update a item
                          3) Delete a item
                          4) Mark item as done/not done
                          5) Mark all items as done/not done
                          6) Go back to list section
                          """);
        var userInput = ValidationHelper.ValidateInputForNumberInRange(1, 6);
        switch (userInput)
        {
            case 1:
                controller.AddNewItemToList(list);
                break;
            case 2:
                for (int i = 0; i < list.Items.Count; i++)
                {
                    Console.WriteLine($"{i+1}{list.Items[i].Name}");
                }
                Console.WriteLine("Please select the item you want to update");
                var itemIndex = ValidationHelper.ValidateInputForNumberInRange(1, list.Items.Count);
                var item = list.Items[itemIndex - 1];
                controller.UpdateItem(list, item);
                break;
            case 3:
                controller.RemoveItem(list);
                break;
            case 4:
                Console.WriteLine("Please select the item you want to mark as done/not done");
                var itemIndexToMark = ValidationHelper.ValidateInputForNumberInRange(1, list.Items.Count);
                var itemToMark = list.Items[itemIndexToMark - 1];
                controller.MarkItemAsDone(list, itemToMark);
                break;
            case 5:
                controller.MarkAllItemsAsDone(list);
                break;
            case 6:
                ViewShoppingLists(controller);
                return;
        }
    }
}