using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class ReturnOrderConfiguration : IEntityTypeConfiguration<ReturnOrder>
{
    public void Configure(EntityTypeBuilder<ReturnOrder> builder)
    {
        builder.ToTable("ReturnOrders");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdReturnOrder")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
        
        builder.Property(d => d.Date)
            .HasColumnName("Date")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(r => r.Reason)
            .HasColumnName("Reason")
            .HasColumnType("nvarchar(max)")
            .IsRequired();
        
        builder.HasOne(ro => ro.StatusDelivery)
            .WithMany(sd => sd.ReturnOrders)
            .HasForeignKey(ro => ro.IdStatusDelivery)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(ro => ro.Order)
            .WithMany(o => o.ReturnOrders)
            .HasForeignKey(ro => ro.IdOrder)
            .OnDelete(DeleteBehavior.NoAction);
    }
}