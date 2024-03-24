namespace OnlineElectronicsStore.Domain.Entity;

public class Profile
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Middlename { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }

    public User User { get; set; }
    public List<Order> Orders { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    public List<WishList> WishLists { get; set; }
    public List<Review> Reviews { get; set; }
}