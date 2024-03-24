using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class WishListConfiguration : IEntityTypeConfiguration<WishList>
{
    public void Configure(EntityTypeBuilder<WishList> builder)
    {
        builder.ToTable("WishLists");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdWishList")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.HasOne(wh => wh.Profile)
            .WithMany(u => u.WishLists)
            .HasForeignKey(wh => wh.IdProfile);
    }
}