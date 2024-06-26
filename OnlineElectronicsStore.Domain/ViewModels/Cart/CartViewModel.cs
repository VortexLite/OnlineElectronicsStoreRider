﻿namespace OnlineElectronicsStore.Domain.ViewModels.Cart;

public class CartViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal Price { get; set; }
    public byte[]? ImageData { get; set; }
}