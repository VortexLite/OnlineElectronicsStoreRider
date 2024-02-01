﻿namespace OnlineElectronicsStore.Domain.Entity;

public class DeliveryType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Order> Orders { get; set; }
}