﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TKIM.Infastracture.Database.Context;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    [DbContext(typeof(TKIM_DbContext))]
    [Migration("20240614072526_product-nullables")]
    partial class productnullables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvoiceProduct", b =>
                {
                    b.Property<Guid>("InvoicesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InvoicesID", "ProductsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("InvoiceProduct");
                });

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

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<decimal?>("PRICE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("STOCK")
                        .HasColumnType("int");

                    b.Property<decimal?>("TAX")
                        .HasColumnType("decimal(18,2)");

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

            modelBuilder.Entity("InvoiceProduct", b =>
                {
                    b.HasOne("TKIM.Entity.Entity.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoicesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKIM.Entity.Entity.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("TKIM.Entity.Entity.Product", b =>
                {
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
