using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.Domain.ViewModels.Product;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[]? ImageBase64 { get; set; }
}