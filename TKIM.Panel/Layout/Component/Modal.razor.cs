using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;

namespace TKIM.Panel.Layout.Component;

public partial class Modal : RazorComponentBase
{
    [Parameter] public EventCallback CloseAction { get; set; }

    [Parameter] public ModalSize Size { get; set; } = ModalSize.DefaultSize;

    [Parameter] public bool CloseBackdrop { get; set; } = false;

    [Parameter] public RenderFragment Body { get; set; }

    [Parameter] public RenderFragment Footer { get; set; }

    [Parameter] public string Title { get; set; } = string.Empty;

    [Parameter] public string CustomClass { get; set; } = string.Empty;

    [Parameter] public string Id { get; set; } = "exampleModal";

    async Task Close()
    {
        await LayoutValue.CloseModal(Id);
        await CloseAction.InvokeAsync();
    }
}

public enum ModalSize
{
    DefaultSize,
    lg,
    sm,
    xl,
    FullScreen
}
