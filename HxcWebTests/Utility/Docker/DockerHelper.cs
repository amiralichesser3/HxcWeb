using System.Diagnostics;

namespace HxcWebTests.Utility.Docker;

public static class DockerHelper
{
    public static async Task RunDockerCommandAsync(string command, string arguments = "")
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "docker",
            Arguments = $" {command} {arguments}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        await process.WaitForExitAsync();
    }
}