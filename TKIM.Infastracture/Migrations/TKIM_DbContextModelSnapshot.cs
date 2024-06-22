﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TKIM.Infastracture.Database.Context;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    [DbContext(typeof(TKIM_DbContext))]
    partial class TKIM_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TKIM.Entity.Entity.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DESCRIPTION")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("IS_ACTIVE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Company", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ADDRESS")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar");

                    b.Property<string>("DESCRIPTION")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EMAIL")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("IS_ACTIVE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NUMBER")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PHONE_NUMBER")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ADDRESS")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar");

                    b.Property<string>("CITY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PHONE_NUMBER")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<string>("SURNAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Invoice", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("COMPANY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CUSTOMER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("INVOICE_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("INVOICE_NUMBER")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar");

                    b.Property<byte[]>("INVOICE_PDF")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<Guid>("PAYMENT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TOTAL")
                        .HasColumnType("decimal");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.HasIndex("COMPANY_ID");

                    b.HasIndex("CUSTOMER_ID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Payment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("COMPANY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CUSTOMER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("INVOICE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("PAYMENT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TOTAL_DISCOUNT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TOTAL_PAYMENT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TOTAL_PRICE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("TOTAL_TAX")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.HasIndex("COMPANY_ID");

                    b.HasIndex("CUSTOMER_ID");

                    b.HasIndex("INVOICE_ID")
                        .IsUnique();

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.PaymentItems", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CURRENT_PROFIT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CURRENT_PURCHASE_PRICE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CURRENT_SALE_PRICE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CURRENT_TAX")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<Guid>("PAYMENT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PRODUCT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QUANTITY_AFTER")
                        .HasColumnType("int");

                    b.Property<int>("QUANTITY_CURRENT")
                        .HasColumnType("int");

                    b.Property<int>("QUANTITY_IN_CART")
                        .HasColumnType("int");

                    b.Property<decimal>("TOTAL_PRICE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.HasIndex("PAYMENT_ID");

                    b.HasIndex("PRODUCT_ID")
                        .IsUnique();

                    b.ToTable("PaymentItems");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EMAIL")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PHONE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ROLE")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar");

                    b.Property<Guid>("SECURITY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SURNAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("UpdateDate")
                        .HasMaxLength(20)
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BARCODE")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<Guid?>("CATEGORY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("COMPANY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DESCRIPTION")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<decimal>("KDV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<decimal>("PROFIT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("PURCHASE_PRICE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("SALE_PRICE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("STOCK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.HasIndex("CATEGORY_ID");

                    b.HasIndex("COMPANY_ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.ProductImage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageSize")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("PRODUCT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("PRODUCT_ID");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Security", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("InsertUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("USERNAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar");

                    b.HasKey("ID");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Invoice", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Company", "Company")
                        .WithMany("Invoices")
                        .HasForeignKey("COMPANY_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKIM.Entity.Entity.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CUSTOMER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Payment", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Company", "Company")
                        .WithMany("Payments")
                        .HasForeignKey("COMPANY_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TKIM.Entity.Entity.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CUSTOMER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKIM.Entity.Entity.Invoice", "Invoice")
                        .WithOne("Payment")
                        .HasForeignKey("TKIM.Entity.Entity.Payment", "INVOICE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.PaymentItems", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Payment", "Payment")
                        .WithMany("BasketItems")
                        .HasForeignKey("PAYMENT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKIM.Entity.Entity.Product", "Product")
                        .WithOne("PaymentItems")
                        .HasForeignKey("TKIM.Entity.Entity.PaymentItems", "PRODUCT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Person", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Security", "Security")
                        .WithOne("Person")
                        .HasForeignKey("TKIM.Entity.Entity.Person", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Security");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Product", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CATEGORY_ID");

                    b.HasOne("TKIM.Entity.Entity.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("COMPANY_ID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.ProductImage", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("PRODUCT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Company", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Payments");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Customer", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Invoice", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Payment", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Product", b =>
                {
                    b.Navigation("PaymentItems")
                        .IsRequired();

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Security", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
