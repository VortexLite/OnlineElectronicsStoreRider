using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class NavigationConfiguration : IEntityTypeConfiguration<Navigation>
{
    public void Configure(EntityTypeBuilder<Navigation> builder)
    {
        builder.ToTable("Navigations");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdNavigation")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.HasOne(nav => nav.Category)
            .WithMany(c => c.Navigations)
            .HasForeignKey(nav => nav.IdCategory);
        
        builder.HasOne(nav => nav.Producer)
            .WithMany(c => c.Navigations)
            .HasForeignKey(nav => nav.IdProducer);
    }
}