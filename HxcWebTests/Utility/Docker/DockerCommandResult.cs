namespace HxcWebTests.Utility.Docker;

public class DockerCommandResult(bool isSuccessful, string? errorMessage)
{
    public bool IsSuccessful { get; set; } = isSuccessful;
    public string? ErrorMessage { get; set; } = errorMessage;
}