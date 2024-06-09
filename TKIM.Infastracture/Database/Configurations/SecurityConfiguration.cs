using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class SecurityConfiguration : IEntityTypeConfiguration<Security>
{
    public void Configure(EntityTypeBuilder<Security> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.USERNAME).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.PASSWORD).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
    }
}
