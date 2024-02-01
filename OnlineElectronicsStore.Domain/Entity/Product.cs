namespace OnlineElectronicsStore.Domain.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

    public int IdCategory { get; set; }
    public Category Category { get; set; }

    public int IdProducer { get; set; }
    public Producer Producer { get; set; }

    public IEnumerable<OrderDetail> OrderDetails { get; set; }
    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
}