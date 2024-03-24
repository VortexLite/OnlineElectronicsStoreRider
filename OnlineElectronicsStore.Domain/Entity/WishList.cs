namespace OnlineElectronicsStore.Domain.Entity;

public class WishList
{
    public int Id { get; set; }
    
    public int IdProfile { get; set; }
    public Profile Profile { get; set; }
    public List<ProductWishList> ProductWishLists { get; set; }
}