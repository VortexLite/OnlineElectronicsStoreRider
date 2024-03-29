namespace OnlineElectronicsStore.Domain.ViewModels.Cart;

public class CartViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[]? ImageData { get; set; }
}