namespace ListProject;

public static class ValidationHelper
{
    public static int ValidateInputForNumberInRange(int min, int max)
    {
        int result;
        do
        {
            if (min == max)
            {
                Console.WriteLine($"You only have one option: {min}\n" +
                                  $"Do you want to continue? (y/n)");
                var choice = ValidateYesOrNo();
                if(choice == "y")
                    return min;
                else
                    return 0;
                
            }
            Console.WriteLine($"Please enter a number between {min} and {max}");
            int.TryParse(Console.ReadLine(), out var input);
            if (input >= min && input <= max)
            {
                result = input;
                break;
            }

            Console.WriteLine("Invalid input");
        } while (true);
        Console.Clear();
        return result;
    }

    public static int ValidateNumberInput()
    {
        int input;
        do
        {
            Console.WriteLine("Please enter a number");
            int.TryParse(Console.ReadLine(), out input);
        } while (input < 0);
        Console.Clear();
        return input;
    }
    
    public static string ValidateTextInput()
    {
        do
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a valid input");
            }
            else
            {
                Console.Clear();
                return input;
            }
        } while (true);
    }

    public static string ValidateYesOrNo()
    {
        string? input;
        do
        {
            Console.WriteLine("Please enter Y or N");
            input = Console.ReadLine()?.ToUpper();
        } while (input != "Y" && input != "N");
        Console.Clear();
        return input;
    }
    
}