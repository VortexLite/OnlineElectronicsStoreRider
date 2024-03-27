using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class CategoryCharacteristicConfiguration : IEntityTypeConfiguration<CategoryCharacteristic>
{
    public void Configure(EntityTypeBuilder<CategoryCharacteristic> builder)
    {
        builder.ToTable("CategoryCharacteristics");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdCategoryCharacteristic")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.HasOne(cc => cc.Category)
            .WithMany(c => c.CategoryCharacteristics)
            .HasForeignKey(cc => cc.IdCategory);

        builder.HasOne(cc => cc.ProductCharacteristic)
            .WithMany(pc => pc.CategoryCharacteristics)
            .HasForeignKey(cc => cc.IdProductCharacteristic);
    }
}