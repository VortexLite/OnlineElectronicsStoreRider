namespace OnlineElectronicsStore.Domain.Entity;

public class Review
{
    public int Id { get; set; }
    public string? Content { get; set; }
    
    public int Rating { get; set; }
    
    public int IdProfile { get; set; }
    public Profile Profile { get; set; }
    
    public int IdOrder { get; set; }
    public Order Order { get; set; }
    
    public int IdCategoryReview { get; set; }
    public CategoryReview CategoryReviews { get; set; }
}