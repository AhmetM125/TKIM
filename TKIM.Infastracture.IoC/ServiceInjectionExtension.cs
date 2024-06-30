
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TKIM.Api.Utils;
using TKIM.Application;
using TKIM.Application.Services.Abstract;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.DA.Concrete;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.IoC;

public static class ServiceInjectionExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Repository
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IInvoiceService, InvoiceService>();

        // Business Services
        services.AddScoped<IPdfGeneratorService, PdfGenerator>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationBase).Assembly));
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
