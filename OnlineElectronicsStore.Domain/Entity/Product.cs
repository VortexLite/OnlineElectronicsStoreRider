namespace OnlineElectronicsStore.Domain.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

    public int IdCategory { get; set; }
    public Category Category { get; set; }
    
    public int IdProducer { get; set; }
    public Producer Producer { get; set; }

    public List<ProductCharacteristic> ProductCharacteristics { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    public List<Image> Images { get; set; }
    public List<ProductWishList> ProductWishLists { get; set; }
}