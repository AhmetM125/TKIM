using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TKIM.Panel.Base;

public class CascadingLayoutBase : LayoutComponentBase
{
    [Inject]
    public IJSRuntime js { get; set; }
    [CascadingParameter]
    public MainLayoutCascadingValue LayoutValue { get; set; }
}
