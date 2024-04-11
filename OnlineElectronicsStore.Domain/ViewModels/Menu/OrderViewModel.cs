namespace OnlineElectronicsStore.Domain.ViewModels.Menu;

public class OrderViewModel
{
    public int Id { get; set; }
    public string DateOrder { get; set; }
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }
    public string NameStatus { get; set; }
    public string NameDelivery { get; set; }
    public string NameAccount { get; set; }
    
}