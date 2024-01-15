using HxcWebTests.Fixture;

namespace HxcWebTests.MainPage;

[TestClass]
public class MainWebIntegrationTests : HxcWebIntegrationTest
{
    [TestMethod]
    public async Task HomePageLoaded_HxcJobsClicked_RoutingWorks()
    {
        await Page.GotoAsync(BaseUrl);

        await Expect(Page).ToHaveTitleAsync(new Regex("Home"));

        var hxcJobs = Page.Locator("text=Hxc Jobs");
        await hxcJobs.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/hxc/jobs"));

        var goToProfile = Page.Locator("#profile-button");
        await goToProfile.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/hxc/profile"));
    }
}