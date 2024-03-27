using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Configurations;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        /*Database.EnsureDeleted();
        Database.EnsureCreated();*/
    }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<DeliveryType> DeliveryTypes { get; set; }
    public DbSet<StatusDelivery> StatusDeliveries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Navigation> Navigations { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<ProductWishList> ProductWishLists { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<ReturnOrder> ReturnOrders { get; set; }
    public DbSet<CategoryReview> CategoryReviews { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<CategoryCharacteristic> CategoryCharacteristics { get; set; }
    public DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryTypeConfiguration());
        modelBuilder.ApplyConfiguration(new StatusDeliveryConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProducerConfiguration());
        modelBuilder.ApplyConfiguration(new NavigationConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new WishListConfiguration());
        modelBuilder.ApplyConfiguration(new ProductWishListConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());
        modelBuilder.ApplyConfiguration(new ReturnOrderConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryReviewConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryCharacteristicConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCharacteristicConfiguration());
    }
}