namespace OnlineElectronicsStore.Domain.Entity;

public class ShoppingCartItem
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
}