
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.IoC;

public static class ServiceInjectionExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {

    }
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnection = configuration.GetConnectionString("TKIM_Connection");

        services.AddDbContext<TKIM_DbContext>(options =>
        {
            options.UseSqlServer(databaseConnection, provider => provider.EnableRetryOnFailure(3));
        });

    }
}
