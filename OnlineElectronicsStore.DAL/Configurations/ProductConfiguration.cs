using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdProduct")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.Property(n => n.Name)
            .HasColumnName("NameProduct")
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(s => s.ShortDescription)
            .HasColumnName("ShortDescription")
            .HasColumnType("varchar(max)")
            .IsRequired();
        
        builder.Property(l => l.LongDescription)
            .HasColumnName("LongDescription")
            .HasColumnType("varchar(max)");
        
        builder.Property(p => p.Price)
            .HasColumnName("Price")
            .HasColumnType("decimal")
            .IsRequired();
        
        builder.HasOne(p => p.Producer)
            .WithMany(pr => pr.Products)
            .HasForeignKey(p => p.IdProducer);
        
        builder.HasOne(p => p.Category)
            .WithMany(pr => pr.Products)
            .HasForeignKey(p => p.IdCategory);
    }
}