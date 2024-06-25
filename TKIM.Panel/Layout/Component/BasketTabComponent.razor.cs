using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Payment;

namespace TKIM.Panel.Layout.Component;

public partial class BasketTabComponent : RazorComponentBase
{
    [Parameter] public int BasketNumber { get; set; }
    [Parameter] public PaymentTabVM BasketTabVM { get; set; }
    [Parameter] public EventCallback OnCartStatusChange { get; set; }
    [Parameter] public EventCallback OnCartRemove { get; set; }
    [Parameter] public List<PaymentTabVM> BasketTabVMs { get; set; }

    private string IsChartActive(bool active)
    {
        return !active ? "btn-outline-secondary" : "btn-secondary";
    }
    private async Task CartStatusChange(bool status)
    {
        BasketTabVM.IsCartActive = !status;
        await OnCartStatusChange.InvokeAsync();
    }
    private async Task DeleteCart()
    {
        BasketTabVMs.Remove(BasketTabVM);
        await OnCartRemove.InvokeAsync();
    }
}
