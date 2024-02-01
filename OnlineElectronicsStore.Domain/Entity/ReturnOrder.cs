namespace OnlineElectronicsStore.Domain.Entity;

public class ReturnOrder
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Reason { get; set; }

    public int IdOrder { get; set; }
    public Order Order { get; set; }
    public int IdStatusDelivery { get; set; }
    public StatusDelivery StatusDelivery { get; set; }
}