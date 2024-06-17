using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Sale;

namespace TKIM.Panel.Pages.Sale.Component;

public partial class SaleBasketComponent : RazorComponentBase
{
    [Parameter] public BasketTabVM BasketTabVM { get; set; }
    [Parameter] public short BasketNo { get; set; }
    private string CartStatus = "";
    private void MinimizeCart()
    {
        CartStatus = "visually-hidden";
    }

    private void RemoveCart()
    {
        Console.WriteLine("ClearBasket");
    }
    private string QuantityAlert(int quantity)
    {
        if (quantity <= 0)
            return "bg-danger";
        else if (quantity <= 5)
            return "bg-warning";
        else
            return "";
    }
}
