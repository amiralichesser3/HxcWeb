using Microsoft.AspNetCore.Components.Web;

namespace HxcUi.Components.JobsComponent;

public partial class Jobs
{
    private const string ProfileUrl = "hxc/profile";
    private const string OrganizationProfileUrl = "hxc/organization/profile";

    private void GoToProfile(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(ProfileUrl);
    }

    private void GoToOrganizationProfile(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(OrganizationProfileUrl);
    }
}