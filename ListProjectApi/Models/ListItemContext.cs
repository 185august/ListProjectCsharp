using Microsoft.EntityFrameworkCore;

namespace ListProjectApi.Models;

public class ListItemContext : DbContext
{
    public ListItemContext(DbContextOptions<ListItemContext> options)
        : base(options)
    {
    }

    public DbSet<ListItem> ListItems { get; set; } = null!;
}