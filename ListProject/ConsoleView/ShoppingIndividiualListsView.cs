namespace ListProject.ConsoleView;

public class ShoppingIndividiualListsView
{
    private void ViewListItem(ShoppingList list)
    {
        Console.WriteLine(list.ToString());
        if (list.Items.Count == 0)
        {
            Console.WriteLine("The list is empty");
        }
        else
        {
            int i = 1;
            foreach (var item in list.Items)
            {
                Console.WriteLine($"{i++}). {item.ToString()}");
            }
        }
    }

    public void ViewIndivudalList(ShoppingList list)
    {
        var individualListController = new ShoppingIndividualListController(list);
        Console.Clear();
        while (true)
        {
            ViewListItem(list);

            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine("""
                              1) Add a new item to the list
                              2) Update a item
                              3) Mark all items as done/not done
                              4) Go back to list section
                              """);
            var userInput = ValidationHelper.ValidateInputForNumberInRange(1, 4);
            switch (userInput)
            {
                case 1:
                    individualListController.AddNewItemToList();
                    break;
                case 2:
                    UpdateAnItem(list, individualListController);
                    break;
                case 3:
                    individualListController.RemoveItem();
                    break;
                case 4:
                    ShoppingListsOverviewView overviewView = new();
                    overviewView.DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            Console.Clear();
        }
    }

    private void UpdateAnItem(ShoppingList list, ShoppingIndividualListController individualListController)
    {
        Console.Clear();
        ViewListItem(list);
        Console.WriteLine("Please select the item you want to update");
        Console.WriteLine($"Please select one of the following options: \n1) Change the name \n2) " +
                          $"Change the amount\n3) Mark the item as done \n4) Delete the item \n5) Go back to your list ");
        var input = ValidationHelper.ValidateInputForNumberInRange(1, 5);
        Console.Clear();
        switch (input)
        {
            case 1:
                individualListController.ChangeNameItem();
                break;
            case 2:
                individualListController.ChangeAmountItem();
                break;
            case 3:

                individualListController.MarkItemAsDone();
                break;
            case 4:
                individualListController.DeleteItem();
                break;
            case 5:
                ViewIndivudalList(list);
                break;
        }
    }
}