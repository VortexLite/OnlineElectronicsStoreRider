using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class StatusDeliveryConfiguration : IEntityTypeConfiguration<StatusDelivery>
{
    public void Configure(EntityTypeBuilder<StatusDelivery> builder)
    {
        builder.ToTable("StatusDelivery");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("IdStatusDelivery")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("NameStatusDelivery")
            .HasColumnType("varchar(50)")
            .IsRequired();
    }
}