using TestContext = Bunit.TestContext;
using HxcUi.Components.Jobs;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Components;

[TestClass]
public class JobsTests : TestContext
{
    [TestMethod]
    public async Task OnPageInitialized_ProfileButtonClicked_RedirectsToProfilePage()
    {
        NavigationManager navigationManager = Substitute.For<NavigationManager>;
        IRenderedComponent<Jobs> cut = RenderComponent(navigationManager);

        cut.FindComponents<MudIconButton>().Single().Click();
        navigationManager.Received(1).NavigateTo(Arg.Is<string>(r => r == "hxc/profile"));
    }

    private IRenderedComponent<Jobs> RenderComponent(NavigationManager navigationManager)
    {
        Services.AddSingleton(navigationManager);
        return RenderComponent<Jobs>();
    }
}