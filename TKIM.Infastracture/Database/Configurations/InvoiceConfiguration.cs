using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.NAME).HasColumnType("nvarchar").HasMaxLength(100);
        builder.Property(x => x.INVOICE_NUMBER).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
        builder.Property(x => x.INVOICE_DATE).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.INVOICE_PDF).IsRequired();
        builder.Property(x => x.TOTAL).HasColumnType("decimal").IsRequired();

        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false); 
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false); 
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false); 

        builder.HasMany(x => x.Products).WithMany(x => x.Invoices);
        builder.HasOne(x => x.Customer).WithMany(x => x.Invoices).HasForeignKey(x => x.CUSTOMER_ID);
        builder.HasOne(x => x.Company).WithMany(x => x.Invoices).HasForeignKey(x => x.COMPANY_ID);



    }
}