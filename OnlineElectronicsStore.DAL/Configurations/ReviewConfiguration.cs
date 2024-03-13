using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdReview")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.Property(n => n.Content)
            .HasColumnName("Content")
            .HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.IdUser);
        
        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.IdProduct);
        
        builder.HasOne(r => r.CategoryReviews)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.IdCategoryReview);
    }
}