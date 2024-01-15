using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        //Database.EnsureCreated();
    }
    
    public DbSet<User> User { get; set; }
    
}