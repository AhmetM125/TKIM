using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;

namespace TKIM.Panel.Layout.Component;

public partial class GenericDropdown<T> : RazorComponentBase
{
    [Parameter] public List<T> Items { get; set; }
    [Parameter] public T SelectedValue { get; set; }
    [Parameter] public EventCallback<T> SelectedValueChanged { get; set; }
    [Parameter] public Func<T, string> DisplaySelector { get; set; }
    [Parameter] public Func<T, string> ValueSelector { get; set; }

    private async Task HandleSelectionChange(ChangeEventArgs e)
    {
        if (e.Value != null)
        {
            var selectedValue = Items.FirstOrDefault(item => ValueSelector(item) == e.Value.ToString());
            if (selectedValue != null)
            {
                SelectedValue = selectedValue;
                await SelectedValueChanged.InvokeAsync(SelectedValue);
            }
        }
    }
}
