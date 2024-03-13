using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class CategoryReviewConfiguration : IEntityTypeConfiguration<CategoryReview>
{
    public void Configure(EntityTypeBuilder<CategoryReview> builder)
    {
        builder.ToTable("CategoryReviews");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("IdCategoryReview")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnName("NameCategory")
            .HasColumnType("nvarchar(50)")
            .IsRequired();
    }
}