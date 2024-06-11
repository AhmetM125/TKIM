using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TKIM.Panel;
using TKIM.Panel.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//
builder.Services.AddScoped<MainLayoutCascadingValue>();
builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddScoped<ClientAuthenticationStateProvider>();
builder.Services.AddBlazoredToast();



//

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),Timeout = TimeSpan.FromMinutes(30) });

await builder.Build().RunAsync();
