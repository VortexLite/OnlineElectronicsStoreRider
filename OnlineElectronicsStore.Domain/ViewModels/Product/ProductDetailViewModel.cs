using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.Domain.ViewModels.Product;

public class ProductDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

    public List<ProductCharacteristic> ProductCharacteristics { get; set; }
    public List<Image> Images { get; set; }
}