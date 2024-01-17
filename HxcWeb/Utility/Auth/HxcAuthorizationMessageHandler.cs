using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace HxcWeb.Utility.Auth;

public class HxcAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation)
    : AuthorizationMessageHandler(provider, navigation)
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            return base.SendAsync(request, cancellationToken);
        }
        catch (AccessTokenNotAvailableException e)
        {
            Console.WriteLine(e);
            // Ignore
            return Task.FromResult(new HttpResponseMessage());
        }
    }
}