using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace TKIM.Panel.Base;

public class RazorComponentBase : ComponentBase
{
    [Inject] protected IJSRuntime JsRuntime { get; set; }
    [Inject] protected NavigationManager Navigator { get; set; }
    protected bool ShowLoader { get; set; } = false;

    [CascadingParameter]
    public MainLayoutCascadingValue LayoutValue { get; set; }
    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationState { get; set; }


}
public enum MessageType
{
    Error,
    Warning,
    Success,
    Info
}
public enum PageStatus
{
    List,
    Update,
    Create,
    Delete,
    ViewItem,
    CSBINS,
    History
}
