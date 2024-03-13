using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("IdImage")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ImageData)
            .IsRequired();
    }
}