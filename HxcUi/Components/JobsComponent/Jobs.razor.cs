using Microsoft.AspNetCore.Components.Web;

namespace HxcUi.Components.JobsComponent;

public partial class Jobs
{
    private const string ProfileUrl = "hxc/profile";
    private const string OrganizationProfileUrl = "hxc/organization/profile";
    private const string OrganizationTodosUrl = "hxc/user/todos";
    private const string TodosUrl = "hxc/organization/todos";

    private void GoToProfile(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(ProfileUrl);
    }

    private void GoToOrganizationProfile(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(OrganizationProfileUrl);
    }

    private void GoToOrganizationTodos(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(OrganizationTodosUrl);
    }

    private void GoToUserTodos(MouseEventArgs obj)
    {
        NavigationManager.NavigateTo(TodosUrl);
    }
}