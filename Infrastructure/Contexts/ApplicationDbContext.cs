namespace Infrastructure.Contexts;

using Domain;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Image> Images => Set<Image>();
}