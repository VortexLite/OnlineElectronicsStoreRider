using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ProductWishListConfiguration : IEntityTypeConfiguration<ProductWishList>
{
    public void Configure(EntityTypeBuilder<ProductWishList> builder)
    {
        builder.ToTable("ProductWishLists");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdProductWishList")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.HasOne(pr => pr.WishList)
            .WithMany(wh => wh.ProductWishLists)
            .HasForeignKey(pr => pr.IdWishList);
        
        builder.HasOne(pr => pr.Product)
            .WithMany(prod => prod.ProductWishLists)
            .HasForeignKey(pr => pr.idProduct);
    }
}