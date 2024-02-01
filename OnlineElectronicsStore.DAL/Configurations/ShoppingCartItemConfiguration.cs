using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.ToTable("ShoppingCartItems");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdShoppingCartItem")
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
        
        builder.HasOne(sci => sci.User)
            .WithMany(u => u.ShoppingCartItems)
            .HasForeignKey(sci => sci.IdUser);

        builder.HasOne(sci => sci.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(sci => sci.IdProduct);
    }
}