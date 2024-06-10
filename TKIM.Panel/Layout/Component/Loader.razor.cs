using Microsoft.AspNetCore.Components;

namespace TKIM.Panel.Layout.Component;

public partial class Loader
{
    [Parameter] public bool IsLoading { get; set; } = false;
}
