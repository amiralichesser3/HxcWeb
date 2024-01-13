namespace HxcWebTests.MainPage;

[TestClass]
public class MainPageTests : PageTest
{
    [TestMethod]
    [DataRow("https://localhost:7268/")] 
 // [DataRow("https://www.helpxchange.com/")]
    public async Task HomePageLoaded_HxcJobsClicked_RoutingWorks(string url)
    {
        await Page.GotoAsync(url);

        await Expect(Page).ToHaveTitleAsync(new Regex("Home"));

        var hxcJobs = Page.Locator("text=Hxc Jobs");
        await hxcJobs.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/hxc/jobs"));

        var goToProfile = Page.Locator("#profile-button");
        await goToProfile.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/hxc/profile"));
    }
}