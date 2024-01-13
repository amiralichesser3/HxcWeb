using HxcUi.Enums;
using HxcUi.Services.Auth;
using HxcUi.Services.Auth.Dto;

namespace HxcWeb.Services.Auth;

public class AuthService : IAuthService
{
    public Task<UserProfile> GetUserProfileAsync()
    {
        UserProfile result = new UserProfile(
            Guid.Parse("3e6e5e80-1b49-47d8-bf8c-0b3ea5d9b43a"),
            "Amirali Safari",
            Gender.Male);
        return Task.FromResult(result);
    }
}
