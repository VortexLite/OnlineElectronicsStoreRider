namespace OnlineElectronicsStore.Domain.Entity;

public class ProductCharacteristic
{
    public int Id { get; set; }
    
    public int IdProduct { get; set; }
    public Product Product { get; set; }
    
    public string CharacteristicName { get; set; }
    public string Value { get; set; }
}