using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using my_blazor_project;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorBootstrap();
//AddCors fixes the CORS error I was getting when trying to connect to the API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
                          {
                              policy.WithOrigins("https://localhost:7237", "https://zakstanyer.com")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowCredentials();
                          });
});


await builder.Build().RunAsync();

