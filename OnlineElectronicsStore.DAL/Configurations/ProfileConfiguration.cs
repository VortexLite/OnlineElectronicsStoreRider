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
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        builder.Property(p => p.Surname)
            .HasColumnName("Surname")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(p => p.Middlename)
            .HasColumnName("Middlename")
            .HasColumnType("varchar(50)");
        
        builder.Property(p => p.Phone)
            .HasColumnName("Phone")
            .HasColumnType("varchar(15)");
        
        builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(p => p.Address)
            .HasColumnName("Address")
            .HasColumnType("varchar(100)");
    }
}