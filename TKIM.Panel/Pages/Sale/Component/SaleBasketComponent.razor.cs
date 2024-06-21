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
    [Parameter] public EventCallback<BasketTabVM> OnModalMaximize { get; set; }
    [Parameter] public EventCallback<(ProductSaleCartVM, short)> OnProductDetail { get; set; }

    private string DisapperCssAnimation = "fade-out";

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
    private async Task ProductDetail(ProductSaleCartVM product)
    {
        product.IsModifying = true;
        await OnProductDetail.InvokeAsync((product, BasketNo));
    }
    private void Discount()
    {
        if (BasketTabVM.TotalDiscount > 100)
        {
            BasketTabVM.TotalDiscount = 0;
            LayoutValue.ShowMessage("İndirim oranı 100%'den büyük olamaz.", MessageType.Error);
        }

        BasketTabVM.PaymentAmount = BasketTabVM.TotalPrice - (BasketTabVM.TotalPrice * (BasketTabVM.TotalDiscount / 100));
    }

    private async Task SubmitBasket()
    {
        if (!BasketTabVM.BasketItems.Any())
        {
            LayoutValue.ShowMessage("Sepetinizde ürün bulunmamaktadır.", MessageType.Error);
            return;
        }

        await OnModalMaximize.InvokeAsync(BasketTabVM);

        //LayoutValue.ShowMessage("Sepet Başarıyla Sisteme Kaydedildi.", MessageType.Success);
        //DisapperCssAnimation = "fade-out hidden";
        //await Task.Delay(2500);
        //await RemoveCart();

    }
}
