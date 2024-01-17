using HxcUi.Extensions;
using HxcUi.Services.Auth;
using HxcWeb.Services.Auth;
using HxcWeb.Utility.Auth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace HxcWeb;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after"); 
        
        builder.Configuration.AddJsonFile("appsettings.Development.Sensitive.json", optional: true, reloadOnChange: true); 
        builder.Configuration.AddJsonFile("appsettings.Production.Sensitive.json", optional: true, reloadOnChange: true); 

        string audience = builder.Configuration["Auth0:Audience"]!;

        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("Auth0", options.ProviderOptions);
            options.ProviderOptions.ResponseType = "code";
            options.ProviderOptions.AdditionalProviderParameters.Add("audience", audience);
        }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();
        
        builder.Services.AddScoped<IAuthService, AuthService>();
        
        builder.Services.RegisterHxcUi();

        builder.Services.AddScoped<AuthorizationMessageHandler>();
        
        builder.Services.AddHttpClient("HxcHttpClient", 
                client => client.BaseAddress = new Uri(builder.Configuration["HxcApiBaseAddress"]!))
            .AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetRequiredService<AuthorizationMessageHandler>();
                handler.ConfigureHandler(new List<string>() { builder.Configuration["HxcApiBaseAddress"]! });
                return handler;
            });

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            .CreateClient("HxcHttpClient"));

        await builder.Build().RunAsync();
    }
}