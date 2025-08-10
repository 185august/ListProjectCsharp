namespace ListProjectApi.Models;

public class ListItem
{
    public long Id { get; set; }
    public long ListId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal? Price { get; set; }
    public bool HasBeenBought { get; set; } = false;
    public string? WhoIsTheRecipient { get; set; }
    public int? WhoAddedItemId { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
