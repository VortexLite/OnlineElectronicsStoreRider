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
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(s => s.ShortDescription)
            .HasColumnName("ShortDescription")
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.Property(l => l.LongDescription)
            .HasColumnName("LongDescription")
            .HasColumnType("varchar(255)");
        
        builder.Property(p => p.Price)
            .HasColumnName("Price")
            .HasColumnType("decimal")
            .IsRequired();
        
        builder.Property(i => i.Image)
            .HasColumnName("Image")
            .HasColumnType("text");
        
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.IdCategory);
        
        builder.HasOne(p => p.Producer)
            .WithMany(pr => pr.Products)
            .HasForeignKey(p => p.IdProducer);
    }
}