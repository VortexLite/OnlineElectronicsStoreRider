using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.ToTable("Producers");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("IdProducer")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("NameProducer")
            .HasColumnType("nvarchar(50)")
            .IsRequired();
    }
}