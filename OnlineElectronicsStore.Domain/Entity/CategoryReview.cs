namespace OnlineElectronicsStore.Domain.Entity;

public class CategoryReview
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Review> Reviews { get; set; }
}