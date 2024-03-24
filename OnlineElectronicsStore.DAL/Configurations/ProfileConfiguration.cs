using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profiles");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("IdProfile")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(50)");

        builder.Property(p => p.Surname)
            .HasColumnName("Surname")
            .HasColumnType("nvarchar(50)");

        builder.Property(p => p.Middlename)
            .HasColumnName("Middlename")
            .HasColumnType("nvarchar(50)");
        
        builder.Property(p => p.Phone)
            .HasColumnName("Phone")
            .HasColumnType("nvarchar(15)");
        
        builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(p => p.Address)
            .HasColumnName("Address")
            .HasColumnType("nvarchar(100)");
    }
}