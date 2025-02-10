using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiniECommerce;
using MiniECommerce.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ✅ Services für Dependency Injection registrieren
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<ReviewService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<WishlistService>();

// ✅ HttpClient für API-Anfragen registrieren
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

// ✅ Sicherstellen, dass Blazor WebAssembly Framework-Dateien geladen werden
builder.Services.AddSingleton<IJSRuntime, JSRuntime>();

// ✅ Fix für statische Dateien, falls Fehler auftreten
builder.RootComponents.Add<App>("#app");

// 🚀 Blazor App starten
await builder.Build().RunAsync();
