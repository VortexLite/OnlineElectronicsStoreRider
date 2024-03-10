namespace OnlineElectronicsStore.Domain.Entity;

public class Producer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; }
    public List<Navigation> Navigations { get; set; }
}