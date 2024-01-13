using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using HxcUi.Components.JobsComponent;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;

namespace HxcUiTests.Components.JobsComponent;

[TestClass]
public class JobsTests : Bunit.TestContext
{
    [TestMethod]
    public void OnPageInitialized_ProfileButtonClicked_RedirectsToProfilePage()
    {
        IRenderedComponent<Jobs> cut = RenderComponent<Jobs>();

        cut.WaitForAssertion(() =>
        {
            cut.FindComponents<MudIconButton>().Single().Instance.OnClick.InvokeAsync();
            Services.GetRequiredService<FakeNavigationManager>().Uri.Should().EndWith("hxc/profile");
        });
    }
}