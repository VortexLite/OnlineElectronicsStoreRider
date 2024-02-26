using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdOrderDetail")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.Property(q => q.Quantity)
            .HasColumnName("Quantity")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(pr => pr.Price)
            .HasColumnName("Price")
            .HasColumnType("decimal")
            .IsRequired();
        
        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.IdOrder);

        builder.HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.IdProduct);
    }
}