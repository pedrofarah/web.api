﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedroFarah.Web.Api.Infrastructure.Context;

#nullable disable

namespace PedroFarah.Web.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Cashback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("FridayValue")
                        .HasColumnType("float")
                        .HasColumnName("FRIDAY_VALUE");

                    b.Property<double>("MondayValue")
                        .HasColumnType("float")
                        .HasColumnName("MONDAY_VALUE");

                    b.Property<long>("ProductCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("TB_PRODUCT_CATEGORY_ID");

                    b.Property<double>("SaturdayValue")
                        .HasColumnType("float")
                        .HasColumnName("SATURDAY_VALUE");

                    b.Property<double>("SundayValue")
                        .HasColumnType("float")
                        .HasColumnName("SUNDAY_VALUE");

                    b.Property<double>("ThursdayValue")
                        .HasColumnType("float")
                        .HasColumnName("THURSDAY_VALUE");

                    b.Property<double>("TuesdayValue")
                        .HasColumnType("float")
                        .HasColumnName("TUESDAY_VALUE");

                    b.Property<double>("WednesdayValue")
                        .HasColumnType("float")
                        .HasColumnName("WEDNESDAY_VALUE");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("TB_CASHBACK", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FridayValue = 15.0,
                            MondayValue = 7.0,
                            ProductCategoryId = 1L,
                            SaturdayValue = 20.0,
                            SundayValue = 25.0,
                            ThursdayValue = 10.0,
                            TuesdayValue = 6.0,
                            WednesdayValue = 2.0
                        },
                        new
                        {
                            Id = 2L,
                            FridayValue = 25.0,
                            MondayValue = 5.0,
                            ProductCategoryId = 2L,
                            SaturdayValue = 30.0,
                            SundayValue = 30.0,
                            ThursdayValue = 20.0,
                            TuesdayValue = 10.0,
                            WednesdayValue = 15.0
                        },
                        new
                        {
                            Id = 3L,
                            FridayValue = 18.0,
                            MondayValue = 3.0,
                            ProductCategoryId = 3L,
                            SaturdayValue = 25.0,
                            SundayValue = 35.0,
                            ThursdayValue = 13.0,
                            TuesdayValue = 5.0,
                            WednesdayValue = 8.0
                        },
                        new
                        {
                            Id = 4L,
                            FridayValue = 20.0,
                            MondayValue = 10.0,
                            ProductCategoryId = 4L,
                            SaturdayValue = 40.0,
                            SundayValue = 40.0,
                            ThursdayValue = 15.0,
                            TuesdayValue = 15.0,
                            WednesdayValue = 15.0
                        });
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("AMOUNT");

                    b.Property<double>("CashbackAmount")
                        .HasColumnType("float")
                        .HasColumnName("CASHBACK_AMOUNT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME");

                    b.Property<string>("PersonDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PERSON_DOCUMENT");

                    b.HasKey("Id");

                    b.ToTable("TB_ORDER", (string)null);
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("AMOUNT");

                    b.Property<double>("CashbackAmount")
                        .HasColumnType("float")
                        .HasColumnName("CASHBACK_AMOUNT");

                    b.Property<int>("ItemNumber")
                        .HasColumnType("int")
                        .HasColumnName("ITEM_NUMBER");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("TB_ORDER_ID");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("TB_PRODUCT_ID");

                    b.Property<double>("Quantity")
                        .HasColumnType("float")
                        .HasColumnName("QUANTITY");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("TB_ORDER_ITEM", (string)null);
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("PRICE");

                    b.Property<long>("ProductCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("TB_PRODUCT_CATEGORY_ID");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("TB_PRODUCT", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "SKOL 1L",
                            Price = 9.5,
                            ProductCategoryId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Name = "BRAHMA 1L",
                            Price = 9.3000000000000007,
                            ProductCategoryId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            Name = "STELLA 1L",
                            Price = 7.4000000000000004,
                            ProductCategoryId = 3L
                        },
                        new
                        {
                            Id = 4L,
                            Name = "BOHEMIA 1L",
                            Price = 8.9000000000000004,
                            ProductCategoryId = 4L
                        });
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("TB_PRODUCT_CATEGORY", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "SKOL"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "BRAHMA"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "STELLA"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "BOHEMIA"
                        });
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Cashback", b =>
                {
                    b.HasOne("PedroFarah.Web.Api.Entity.ProductCategory", "ProductCategory")
                        .WithMany("Cashbacks")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.OrderItem", b =>
                {
                    b.HasOne("PedroFarah.Web.Api.Entity.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PedroFarah.Web.Api.Entity.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Product", b =>
                {
                    b.HasOne("PedroFarah.Web.Api.Entity.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PedroFarah.Web.Api.Entity.ProductCategory", b =>
                {
                    b.Navigation("Cashbacks");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
