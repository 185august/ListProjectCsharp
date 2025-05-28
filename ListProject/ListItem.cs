namespace ListProject;

public class ListItem
{
    public string Name { get; private set; }
    public int Amount { get; private set; }
    public string Id { get; }
    public bool IsDone { get; private set; }

    public ListItem(string name, int amount)
    {
        Name = name;
        Amount = amount;
        Id = Guid.NewGuid().ToString();
        IsDone = false;
    }

    public override string ToString()
    {
        return $"Product: {Name}, Amount: {Amount}, Bought?: {IsDone}";
    }
    public void MarkAsDone()
    {
        IsDone = true;
    }
    
    public void MarkAsNotDone()
    {
        IsDone = false;
    }
    
    public void ChangeAmount(int amount)
    {
        Amount = amount;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
}
