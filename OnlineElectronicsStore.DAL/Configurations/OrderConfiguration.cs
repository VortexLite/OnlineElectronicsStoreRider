﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdOrder")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.Property(d => d.DateOrder)
            .HasColumnName("DateOrder")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(t => t.TotalCost)
            .HasColumnName("TotalCost")
            .HasColumnType("decimal")
            .IsRequired();
        
        builder.Property(a => a.Address)
            .HasColumnName("Address")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
        
        builder.HasOne(o => o.Profile)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.IdProfile);

        builder.HasOne(o => o.DeliveryType)
            .WithOne(d => d.Orders)
            .HasForeignKey<Order>(d => d.IdDeliveryType);

        builder.HasOne(o => o.StatusDelivery)
            .WithMany(sd => sd.Orders)
            .HasForeignKey(o => o.IdStatusDelivery);
    }
}