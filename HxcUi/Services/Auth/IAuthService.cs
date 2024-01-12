using HxcUi.Services.Auth.Dto;

namespace HxcUi.Services.Auth;

public interface IAuthService
{
    Task<UserProfile> GetUserProfileAsync();
}