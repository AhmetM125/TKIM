using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Product;
using TKIM.Panel.ViewModels.Sale;

namespace TKIM.Panel.Pages.Sale.Component;

public partial class SaleBasketComponent : RazorComponentBase
{
    [Parameter] public BasketTabVM BasketTabVM { get; set; }
    [Parameter] public List<BasketTabVM> BasketItems { get; set; }
    [Parameter] public short BasketNo { get; set; }
    [Parameter] public EventCallback OnMinimize { get; set; }
    [Parameter] public EventCallback OnRemove { get; set; }
    [Parameter] public EventCallback<ProductSaleCartVM> OnProductDetail { get; set; }

    private string CartStatus = "";
    private async Task MinimizeCart()
    {
        BasketTabVM.IsCartActive = false;
        await OnMinimize.InvokeAsync();
    }

    private async Task RemoveCart()
    {
        BasketItems.Remove(BasketTabVM);
        await OnRemove.InvokeAsync();
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
    void ProductDetail(ProductSaleCartVM product)
    {
        OnProductDetail.InvokeAsync(product);
    }
}
