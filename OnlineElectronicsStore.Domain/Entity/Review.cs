namespace OnlineElectronicsStore.Domain.Entity;

public class Review
{
    public int Id { get; set; }
    public string? Content { get; set; }
    
    public string Rating { get; set; }
    
    public int? IdUser { get; set; }
    public User User { get; set; }
    
    public int? IdOrder { get; set; }
    public Order Order { get; set; }
    
    public int? IdProduct { get; set; }
    public Product Product { get; set; }
    
    public int IdCategoryReview { get; set; }
    public CategoryReview CategoryReviews { get; set; }
}