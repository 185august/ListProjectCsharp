namespace ListProject.ConsoleView;

public class DashboardView
{
    public void DisplayMenu()
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
                ShoppingListsOverviewView overviewView = new ShoppingListsOverviewView();
                overviewView.DisplayMenu();
                break;
            case 2:
                Environment.Exit(0);
                break;
        }
    }
}