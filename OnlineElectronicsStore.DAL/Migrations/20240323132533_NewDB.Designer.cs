﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineElectronicsStore.DAL;

#nullable disable

namespace OnlineElectronicsStore.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240323132533_NewDB")]
    partial class NewDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NameCategory");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.CategoryReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCategoryReview");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NameCategory");

                    b.HasKey("Id");

                    b.ToTable("CategoryReviews", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.DeliveryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdDeliveryType");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NameDeliveryType");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypes", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdImage");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Navigation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdNavigation");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdProducer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdProducer");

                    b.ToTable("Navigations", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdOrder");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOrder");

                    b.Property<int>("IdDeliveryType")
                        .HasColumnType("int");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<int>("IdStatusDelivery")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal")
                        .HasColumnName("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("IdDeliveryType")
                        .IsUnique();

                    b.HasIndex("IdProfile");

                    b.HasIndex("IdStatusDelivery");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdOrderDetail");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdProducer");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NameProducer");

                    b.HasKey("Id");

                    b.ToTable("Producers", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdProduct");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdProducer")
                        .HasColumnType("int");

                    b.Property<string>("LongDescription")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("LongDescription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("NameProduct");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ShortDescription");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdProducer");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.ProductWishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdProductWishList");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdWishList")
                        .HasColumnType("int");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdWishList");

                    b.HasIndex("idProduct");

                    b.ToTable("ProductWishLists", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdProfile");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Middlename");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("Phone");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.ToTable("Profiles", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.ReturnOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdReturnOrder");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("Date");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdStatusDelivery")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Reason");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdStatusDelivery");

                    b.ToTable("ReturnOrders", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdReview");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<int>("IdCategoryReview")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("IdProfile")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoryReview");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdProfile");

                    b.HasIndex("OrderId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdRole");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NameRole");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdShoppingCartItem");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdProfile");

                    b.ToTable("ShoppingCartItems", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.StatusDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdStatusDelivery");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NameStatusDelivery");

                    b.HasKey("Id");

                    b.ToTable("StatusDelivery", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUser");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdProfile")
                        .HasColumnType("int");

                    b.Property<int?>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.HasIndex("IdProfile")
                        .IsUnique()
                        .HasFilter("[IdProfile] IS NOT NULL");

                    b.HasIndex("IdRole");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdWishList");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProfile");

                    b.ToTable("WishLists", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Image", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Navigation", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Category", "Category")
                        .WithMany("Navigations")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Producer", "Producer")
                        .WithMany("Navigations")
                        .HasForeignKey("IdProducer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Order", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.DeliveryType", "DeliveryType")
                        .WithOne("Orders")
                        .HasForeignKey("OnlineElectronicsStore.Domain.Entity.Order", "IdDeliveryType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Profile", "Profile")
                        .WithMany("Orders")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.StatusDelivery", "StatusDelivery")
                        .WithMany("Orders")
                        .HasForeignKey("IdStatusDelivery")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryType");

                    b.Navigation("Profile");

                    b.Navigation("StatusDelivery");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.OrderDetail", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Product", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("IdProducer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.ProductWishList", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.WishList", "WishList")
                        .WithMany("ProductWishLists")
                        .HasForeignKey("IdWishList")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Product", "Product")
                        .WithMany("ProductWishLists")
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.ReturnOrder", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Order", "Order")
                        .WithMany("ReturnOrders")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.StatusDelivery", "StatusDelivery")
                        .WithMany("ReturnOrders")
                        .HasForeignKey("IdStatusDelivery")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("StatusDelivery");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Review", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.CategoryReview", "CategoryReviews")
                        .WithMany("Reviews")
                        .HasForeignKey("IdCategoryReview")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("IdProduct");

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Profile", "Profile")
                        .WithMany("Reviews")
                        .HasForeignKey("IdProfile");

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Order", "Order")
                        .WithMany("Reviews")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryReviews");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.ShoppingCartItem", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Product", "Product")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Profile", "Profile")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.User", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Profile", "Profile")
                        .WithOne("User")
                        .HasForeignKey("OnlineElectronicsStore.Domain.Entity.User", "IdProfile");

                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("IdRole");

                    b.Navigation("Profile");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.WishList", b =>
                {
                    b.HasOne("OnlineElectronicsStore.Domain.Entity.Profile", "Profile")
                        .WithMany("WishLists")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Category", b =>
                {
                    b.Navigation("Navigations");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.CategoryReview", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.DeliveryType", b =>
                {
                    b.Navigation("Orders")
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ReturnOrders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Producer", b =>
                {
                    b.Navigation("Navigations");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("OrderDetails");

                    b.Navigation("ProductWishLists");

                    b.Navigation("Reviews");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Profile", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("ShoppingCartItems");

                    b.Navigation("User")
                        .IsRequired();

                    b.Navigation("WishLists");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.StatusDelivery", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ReturnOrders");
                });

            modelBuilder.Entity("OnlineElectronicsStore.Domain.Entity.WishList", b =>
                {
                    b.Navigation("ProductWishLists");
                });
#pragma warning restore 612, 618
        }
    }
}
