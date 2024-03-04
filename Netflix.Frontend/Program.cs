using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Netflix.Frontend;
using Netflix.Frontend.Services;
using Netflix.Frontend.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var webApiUrl = builder.Configuration.GetValue<string>("WebApiUrl");

builder.Services.AddScoped<IMoviesDataService, MoviesDataService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();


await builder.Build().RunAsync();


