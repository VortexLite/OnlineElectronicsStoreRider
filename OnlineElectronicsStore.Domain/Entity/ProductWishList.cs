namespace OnlineElectronicsStore.Domain.Entity;

public class ProductWishList
{
    public int Id { get; set; }

    public int IdWishList { get; set; }
    public WishList WishList { get; set; }
    
    public int idProduct { get; set; }
    public Product Product { get; set; }
}