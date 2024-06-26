using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Payment;
using TKIM.Panel.ViewModels.PaymentItems;

namespace TKIM.Panel.Pages.Sale.Component;

public partial class SaleBasketComponent : RazorComponentBase
{
    [Parameter] public PaymentTabVM BasketTabVM { get; set; }
    [Parameter] public List<PaymentTabVM> BasketItems { get; set; }
    [Parameter] public short BasketNo { get; set; }
    [Parameter] public EventCallback OnMinimize { get; set; }
    [Parameter] public EventCallback OnRemove { get; set; }
    [Parameter] public EventCallback<PaymentTabVM> OnModalMaximize { get; set; }
    [Parameter] public EventCallback<(PaymentItemVM, short)> OnProductDetail { get; set; }
    [Parameter] public bool IsBasketFullScreen { get; set; }

    [Inject] private IPaymentService PaymentService { get; set; }

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
    private async Task ProductDetail(PaymentItemVM product)
    {
        product.IsModifying = true;
        await OnProductDetail.InvokeAsync((product, BasketNo));
    }
    private async Task GenerateReceipt()
    {
        try
        {
            await JsRuntime.InvokeVoidAsync("downloadFileFromUrlWithObject", $"https://localhost:7205/api/v1/Invoice/GenerateInvoice", $"{DateTime.Now.ToString("dd-MM-yyyy-HH-mm").Replace("-", "")} - Fatura", BasketTabVM);
            LayoutValue.ShowMessage("Fatura başarıyla oluşturuldu.", MessageType.Success);
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Fatura oluşturulurken bir hata oluştu!", MessageType.Error);
        }

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

    private async Task MaximixeBasket()
    {
        if (!BasketTabVM.BasketItems.Any())
        {
            LayoutValue.ShowMessage("Sepetinizde ürün bulunmamaktadır.", MessageType.Error);
            return;
        }

        await OnModalMaximize.InvokeAsync(BasketTabVM);
    }
    private void RemoveProductFromCart(PaymentItemVM product)
    {
        BasketTabVM.BasketItems.Remove(product);
        BasketTabVM.TotalPrice -= product.TotalPrice;
        BasketTabVM.PaymentAmount -= product.TotalPrice;
        BasketTabVM.TotalTax -= product.Kdv;
    }
    private async Task SubmitBasket()
    {
        try
        {
            ShowLoader = true;
            if (!BasketTabVM.BasketItems.Any())
            {
                LayoutValue.ShowMessage("Sepetinizde ürün bulunmamaktadır.", MessageType.Error);
                return;
            }

            await PaymentService.SubmitPaymentAsync(BasketTabVM);
            LayoutValue.ShowMessage("Ödeme işlemi başarıyla gerçekleştirildi.", MessageType.Success);
            DisapperCssAnimation = "fade-out hidden";
            await RemoveCart();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Ödeme işlemi sırasında bir hata oluştu.", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }

    }
}
