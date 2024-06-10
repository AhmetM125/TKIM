using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.NAME).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.DESCRIPTION).HasMaxLength(200).HasColumnType("nvarchar").IsRequired(false);
        builder.Property(x => x.ADDRESS).HasMaxLength(200).HasColumnType("nvarchar").IsRequired(false);
        builder.Property(x => x.PHONE_NUMBER).HasMaxLength(30).HasColumnType("nvarchar").IsRequired(false);
        builder.Property(x => x.NUMBER).HasMaxLength(30).HasColumnType("nvarchar").IsRequired(false);

        builder.Property(x => x.InsertUser).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.UpdateUser).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired();


    }
}

