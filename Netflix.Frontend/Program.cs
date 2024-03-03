using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Netflix.Frontend;
using Netflix.Frontend.Services.Interfaces;
using NetflixApi.Api.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var webApiUrl = builder.Configuration.GetValue<string>("WebApiUrl");

builder.Services.AddScoped<IMoviesDataService, MoviesDataService>();

await builder.Build().RunAsync();


