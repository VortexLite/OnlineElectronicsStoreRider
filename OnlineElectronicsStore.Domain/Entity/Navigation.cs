namespace OnlineElectronicsStore.Domain.Entity;

public class Navigation
{
    public int Id { get; set; }

    public int IdCategory { get; set; }
    public Category Category { get; set; }
    
    public int IdProducer { get; set; }
    public Producer Producer { get; set; }
}