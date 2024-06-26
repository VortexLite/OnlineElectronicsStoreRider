﻿namespace OnlineElectronicsStore.Domain.Entity;

public class Order
{
    public int Id { get; set; }
    public DateTime DateOrder { get; set; }
    public decimal TotalCost { get; set; }
    public string Address { get; set; }

    public int IdProfile { get; set; }
    public Profile Profile { get; set; }

    public int IdDeliveryType { get; set; }
    public DeliveryType DeliveryType { get; set; }

    public int IdStatusDelivery { get; set; }
    public StatusDelivery StatusDelivery { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
    public List<ReturnOrder> ReturnOrders { get; set; }
    public List<Review> Reviews { get; set; }
}