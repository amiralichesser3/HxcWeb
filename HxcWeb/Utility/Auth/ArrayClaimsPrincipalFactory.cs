using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace HxcWeb.Utility.Auth;

public class ArrayClaimsPrincipalFactory<TAccount>(IAccessTokenProviderAccessor accessor)
    : AccountClaimsPrincipalFactory<TAccount>(accessor)
    where TAccount : RemoteUserAccount
{
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        TAccount account,
        RemoteAuthenticationUserOptions options)
    {
        Console.WriteLine($"Creating user for account:");
        ClaimsPrincipal user = await base.CreateUserAsync(account, options);

        if (account is null)
        {
            return user;
        }

        ClaimsIdentity claimsIdentity = (ClaimsIdentity)user.Identity!;
        
        foreach (var kvp in account.AdditionalProperties)
        {
            if (kvp.Value is not JsonElement {ValueKind: JsonValueKind.Array} element) continue;
            claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(kvp.Key));

            var claims = element.EnumerateArray()
                .Select(x => new Claim(kvp.Key, x.ToString()));

            claimsIdentity.AddClaims(claims);
        }
        return user;
    }
}