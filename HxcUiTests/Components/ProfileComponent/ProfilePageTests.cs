using HxcUi.Components.ProfileComponent;
using HxcUi.Services.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;

namespace HxcUiTests.Components.ProfileComponent;

[TestClass]
public class ProfilePageTests : Bunit.TestContext
{
    [TestMethod]
    public async Task OnInitialized_AuthServiceCalledProperly()
    {
        IAuthService mockAuthService = Substitute.For<IAuthService>();
        RegisterService(mockAuthService);
        
        RenderComponent<ProfilePage>();

        await mockAuthService.Received(1).GetUserProfileAsync();
    }

    private void RegisterService(IAuthService mockAuthService)
    {
        Services.RemoveAll<IAuthService>();
        Services.AddSingleton(mockAuthService);
    }
}