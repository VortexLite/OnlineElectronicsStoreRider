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

    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
}