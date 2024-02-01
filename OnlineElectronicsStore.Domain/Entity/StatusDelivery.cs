namespace OnlineElectronicsStore.Domain.Entity;

public class StatusDelivery
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<ReturnOrder> ReturnOrders { get; set; }
}