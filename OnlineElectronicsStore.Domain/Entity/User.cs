namespace OnlineElectronicsStore.Domain.Entity;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public int IdRole { get; set; }
    public Role Role { get; set; }

    public int IdProfile { get; set; }
    public Profile Profile { get; set; }
    
    public List<Order> Orders { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    public List<WishList> WishLists { get; set; }
    public List<Review> Reviews { get; set; }
    public List<UserRole> UserRoles { get; set; }
}