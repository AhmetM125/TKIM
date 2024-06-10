using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;

namespace TKIM.Panel.Layout;

public partial class Sidebar : RazorComponentBase
{
    private string ActiveLink = "/";

    private void SetActiveLink(string link)
    {
        ActiveLink = link;
    }
    private string IsActiveLink(string link)
    {
        return ActiveLink == link ? "active" : "";
    }
    private void ActiveNavigator(string address)
    {
        ActiveLink = address;
        Navigator.NavigateTo(address);
    }
}
