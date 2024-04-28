using Microsoft.AspNetCore.Http;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.Domain.ViewModels.Menu;

public class CreateProductViewModel
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public int IdCategory { get; set; }
    public int IdProducer { get; set; }
    public List<IFormFile> Images { get; set; }
    public List<Entity.Category> Categories { get; set; }
    public List<Producer> Producers { get; set; }
}