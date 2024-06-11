using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TKIM.Panel;
using TKIM.Panel.Base;
using TKIM.Panel.DI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//
builder.Services.AddScoped<MainLayoutCascadingValue>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddServices();
//builder.Services.AddScoped<ClientAuthenticationStateProvider>();
builder.Services.AddBlazoredToast();



//

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7205/api/"),
    Timeout = TimeSpan.FromMinutes(30)
});

await builder.Build().RunAsync();
