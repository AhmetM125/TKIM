using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Concrete;

namespace TKIM.Panel.DI;

public static class DependencyInjection 
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPaymentService, PaymentService>();
    }
}
