namespace OnlineElectronicsStore.Domain.Entity;

public class Image
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    //public Product Product { get; set; }
    public byte[] ImageData { get; set; }
}