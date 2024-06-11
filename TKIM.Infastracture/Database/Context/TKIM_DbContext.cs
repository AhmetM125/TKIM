using Microsoft.EntityFrameworkCore;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Context;

public class TKIM_DbContext : DbContext
{
    public TKIM_DbContext(DbContextOptions<TKIM_DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TKIM_DbContext).Assembly);
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Security> Securities { get; set; }

    //public DbSet<PermissionRole> PermissionRoles { get; set; }
    //public DbSet<Permission> Permissions { get; set; }
    //public DbSet<Role> Roles { get; set; }
    //public DbSet<UserRole> UserRoles { get; set; }


    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var currentTime = DateTime.UtcNow;
        var currentUserId = Guid.Empty; // i need session user id here (later)
        var currentUser = "ahmet.yurdal"; // i need session user name here (later)

        var changes = this.ChangeTracker.Entries();
        foreach (var entity in changes)
        {
            if (entity.State == EntityState.Added)
            {
                entity.Property("InsertDate").CurrentValue = currentTime;
                entity.Property("InsertUser").CurrentValue = currentUser;
            }
            else if (entity.State == EntityState.Modified)
            {
                entity.Property("UpdateDate").CurrentValue = currentTime;
                entity.Property("UpdateUser").CurrentValue = currentUser;
            }
        }

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges()
    {
        var currentTime = DateTime.UtcNow;
        var currentUserId = Guid.Empty; // i need session user id here (later)
        var currentUser = "ahmet.yurdal"; // i need session user name here (later)

        var changes = this.ChangeTracker.Entries();
        foreach (var entity in changes)
        {
            if (entity.State == EntityState.Added)
            {
                entity.Property("InsertDate").CurrentValue = currentTime;
                entity.Property("InsertUser").CurrentValue = currentUser;
            }
            else if (entity.State == EntityState.Modified)
            {
                entity.Property("UpdateDate").CurrentValue = currentTime;
                entity.Property("UpdateUser").CurrentValue = currentUser;
            }
        }
        return base.SaveChanges();
    }


}
