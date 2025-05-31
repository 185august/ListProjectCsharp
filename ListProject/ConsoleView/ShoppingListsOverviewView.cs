namespace ListProject.ConsoleView;

public class ShoppingListsOverviewView
{
    private readonly ShoppingIndividiualListsView _individualListsView = new();
    public void DisplayMenu()
    {
        while (true)
        {
            var controller = new ShoppingListOverviewController();
            
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
                    ViewShoppingLists();
                    var list = controller.SelectListToView();
                    _individualListsView.ViewIndivudalList(list);
                    break;
                case 2:
                    var newList =controller.CreateNewShoppingList();
                    _individualListsView.ViewIndivudalList(newList);
                    break;
                case 3:
                    ViewShoppingLists();
                    controller.RemoveList();
                    break;
                case 4:
                    DashboardView dashboard = new();
                    dashboard.DisplayMenu();
                    return;
            }
        }
    }

    public void ViewShoppingLists()
    {
        var controller = new ShoppingListOverviewController();
        var lists = controller.ViewAllShoppingLists();
        if (lists != null && lists.Count != 0)
        {
            var i = 1;
            foreach (var list in lists)
            {
                Console.WriteLine($"{i++}). {list.Name}");
            }
        }
        else
        {
            Console.WriteLine("You have no shopping lists");
            Console.WriteLine("Do you want to create a new list? (y/n)");
            if (!ValidationHelper.ValidateYesOrNo()) return;
            var newShoppingList = controller.CreateNewShoppingList();
            _individualListsView.ViewIndivudalList(newShoppingList);
        }
    }
}