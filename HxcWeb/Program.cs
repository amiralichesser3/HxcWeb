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

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
 
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("Auth0", options.ProviderOptions);
            options.ProviderOptions.ResponseType = "code";
            options.ProviderOptions.DefaultScopes.Add("roles");
        }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

        builder.Services.AddScoped(sp =>
            new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.RegisterHxcUI();
        
        await builder.Build().RunAsync();
    }
}