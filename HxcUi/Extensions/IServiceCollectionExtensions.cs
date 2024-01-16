using HxcApiClient.Ioc;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace HxcUi.Extensions;

public static class IServiceCollectionExtensions
{
    public static void RegisterHxcUi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices();
        serviceCollection.SetupHxcApiClient();
    }
}