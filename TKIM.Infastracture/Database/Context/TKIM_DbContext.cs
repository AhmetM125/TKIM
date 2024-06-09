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

}
