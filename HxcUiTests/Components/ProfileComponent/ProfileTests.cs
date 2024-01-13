using Bunit;
using FluentAssertions;
using HxcUi.Components.ProfileComponent;
using HxcUi.Enums;
using HxcUi.Services.Auth.Dto;
using MudBlazor;

namespace HxcUiTests.Components.ProfileComponent;

[TestClass]
public class ProfileTests : Bunit.TestContext
{
    [TestMethod]
    public void OnInitialized_NullInput_NoTextShouldBeDisplayed()
    {
        IRenderedComponent<Profile> cut = RenderComponent<Profile>();

        cut.FindComponents<MudText>().Should().BeEmpty();
    }
    
    [TestMethod]
    public void OnInitialized_ValidInput_UserNameIsDisplayed()
    {
        UserProfile userProfile = new UserProfile(Guid.NewGuid(),
            Guid.NewGuid().ToString(),
            Gender.Female);

        IRenderedComponent<Profile> cut = RenderComponent<Profile>(
            parameters =>
                parameters.Add(p => p.UserProfile, userProfile));

        IRenderedComponent<MudText> mudTextElement = cut.FindComponents<MudText>().Single();
        mudTextElement.Markup.Should().Contain($">{userProfile.UserName}<");
    }
}