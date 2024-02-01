namespace OnlineElectronicsStore.Domain.Entity;

public class OrderDetail
{
    public int Id { get; set; }
    public int IdOrder { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}