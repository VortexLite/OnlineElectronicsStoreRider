namespace OnlineElectronicsStore.Domain.Entity;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<CategoryCharacteristic> CategoryCharacteristics { get; set; }
    public List<Navigation> Navigations { get; set; }
}