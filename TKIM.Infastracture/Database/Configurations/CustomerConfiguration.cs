using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.NAME).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.SURNAME).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
        builder.Property(x => x.ADDRESS).HasMaxLength(200).HasColumnType("nvarchar").IsRequired(false);
        builder.Property(x => x.PHONE_NUMBER).HasMaxLength(30).HasColumnType("nvarchar").IsRequired(false);

        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20);

    }
}
