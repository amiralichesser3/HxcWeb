using HxcWebTests.Utility.Docker;

namespace HxcWebTests.Fixture;

public class HxcPageTest : PageTest
{
    protected string BaseUrl => $"http://localhost:5000/";

    [TestInitialize]
    public async Task InitializeAsync()
    {
        await DockerHelper.RunDockerCommandAsync("compose", "up -d");
    }

    [TestCleanup]
    public async Task CleanupAsync()
    {
        await DockerHelper.RunDockerCommandAsync("compose", "down");
    }
}