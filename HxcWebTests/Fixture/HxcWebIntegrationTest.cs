using System.Text;
using HxcWebTests.Utility.Docker;
using Microsoft.Extensions.Configuration;

namespace HxcWebTests.Fixture;

[TestCategory("Integration")]
public abstract class HxcWebIntegrationTest : PageTest
{
    protected static string BaseUrl => $"http://localhost:5000/";

    [TestInitialize]
    public async Task InitializeAsync()
    {
        await DockerHelper.RunDockerCommandAsync(GetComposeCommand(), "up -d");
    }

    [TestCleanup]
    public async Task CleanupAsync()
    {
        await DockerHelper.RunDockerCommandAsync(GetComposeCommand(), "down");
    }

    private string GetComposeCommand()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string? dockerComposeFile = configuration["docker:composeFile"];
        StringBuilder command = new StringBuilder("compose");
        if (dockerComposeFile is not null)
        {
            command.Append($" -f {dockerComposeFile}");
        }

        return command.ToString();
    }
}