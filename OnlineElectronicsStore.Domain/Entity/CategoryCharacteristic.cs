namespace OnlineElectronicsStore.Domain.Entity;

public class CategoryCharacteristic
{
    public int Id { get; set; }
    
    public int IdCategory { get; set; }
    public Category Category { get; set; }
    
    public int IdProductCharacteristic { get; set; }
    public ProductCharacteristic ProductCharacteristic { get; set; }
}