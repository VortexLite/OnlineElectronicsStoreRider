namespace OnlineElectronicsStore.Domain.Entity;

public class StatusDelivery
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Order> Orders { get; set; }
    public List<ReturnOrder> ReturnOrders { get; set; }
}