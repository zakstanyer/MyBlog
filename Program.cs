using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using my_blazor_project;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorBootstrap();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
                          {
                              policy.WithOrigins("http://localhost:7237", "https://zakstanyer.com/RESTAPI")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()

                                                  .AllowAnyOrigin();
                          });
});


await builder.Build().RunAsync();
