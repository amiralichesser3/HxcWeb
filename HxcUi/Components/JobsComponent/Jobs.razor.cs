using Microsoft.AspNetCore.Components.Web;

namespace HxcUi.Components.JobsComponent;

public partial class Jobs
{
    private const string ProfileUrl = "hxc/profile";

    private void GoToProfile(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(ProfileUrl);
    }
}