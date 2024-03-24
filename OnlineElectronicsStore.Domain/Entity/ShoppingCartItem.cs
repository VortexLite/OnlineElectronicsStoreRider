namespace OnlineElectronicsStore.Domain.Entity;

public class ShoppingCartItem
{
    public int Id { get; set; }
    
    public int IdProfile { get; set; }
    public Profile Profile { get; set; }
    
    public int IdProduct { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    
    
}