﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(k => k.Id);
        
        builder.Property(k => k.Id)
            .HasColumnName("IdUser")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Login)
            .HasColumnName("Login")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(p => p.Password)
            .HasColumnName("Password")
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        
        builder.HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<User>(p => p.IdProfile);
        
        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(p => p.IdRole);
    }
}