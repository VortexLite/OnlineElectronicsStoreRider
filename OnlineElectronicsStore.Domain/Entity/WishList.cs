namespace OnlineElectronicsStore.Domain.Entity;

public class WishList
{
    public int Id { get; set; }
    
    public int IdUser { get; set; }
    public User User { get; set; }
    public List<ProductWishList> ProductWishLists { get; set; }
}