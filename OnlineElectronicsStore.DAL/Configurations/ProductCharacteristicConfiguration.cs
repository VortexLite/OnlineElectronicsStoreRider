using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ProductCharacteristicConfiguration : IEntityTypeConfiguration<ProductCharacteristic>
{
    public void Configure(EntityTypeBuilder<ProductCharacteristic> builder)
    {
        builder.ToTable("ProductCharacteristics");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdProductCharacteristic")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.Property(n => n.CharacteristicName)
            .HasColumnName("CharacteristicName")
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(s => s.Value)
            .HasColumnName("Value")
            .HasColumnType("varchar(max)")
            .IsRequired();
        
        builder.HasOne(c => c.Product)
            .WithMany(pr => pr.ProductCharacteristics)
            .HasForeignKey(p => p.IdProduct);
    }
}