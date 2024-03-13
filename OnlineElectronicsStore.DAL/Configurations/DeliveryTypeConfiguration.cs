using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class DeliveryTypeConfiguration : IEntityTypeConfiguration<DeliveryType>
{
    public void Configure(EntityTypeBuilder<DeliveryType> builder)
    {
        builder.ToTable("DeliveryTypes");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("IdDeliveryType")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("NameDeliveryType")
            .HasColumnType("nvarchar(50)")
            .IsRequired();
    }
}