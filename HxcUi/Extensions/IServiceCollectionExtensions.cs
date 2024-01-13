using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

public static class IServiceCollectionExtensions
{
    public static void RegisterHxcUI(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices();
    }
}