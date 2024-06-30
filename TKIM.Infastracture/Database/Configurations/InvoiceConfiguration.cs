using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.DESCRIPTION).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(200);
        builder.Property(x => x.INVOICE_NUMBER).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
        builder.Property(x => x.INVOICE_DATE).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.INVOICE_PDF).IsRequired();
        builder.Property(x => x.TOTAL).HasColumnType("decimal").IsRequired();

        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);

        builder.HasOne(x => x.Customer).WithMany(x => x.Invoices).HasForeignKey(x => x.CUSTOMER_ID);
        builder.HasOne(x => x.Company).WithMany(x => x.Invoices).HasForeignKey(x => x.COMPANY_ID);
        builder.HasOne(x => x.Payment).WithOne(x => x.Invoice).HasForeignKey<Payment>(x => x.INVOICE_ID);

        builder.Property(x=>x.COMPANY_ID).IsRequired(false);
        builder.Property(x => x.CUSTOMER_ID).IsRequired(false);



    }
}