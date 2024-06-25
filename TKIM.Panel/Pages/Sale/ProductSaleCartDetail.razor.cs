using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Payment;
using TKIM.Panel.ViewModels.PaymentItems;

namespace TKIM.Panel.Pages.Sale;

public partial class ProductSaleCartDetail : RazorComponentBase
{
    [Parameter] public PaymentItemVM PaymentItemCartVM { get; set; }
    [Parameter] public List<PaymentTabVM> BasketTabVMs { get; set; }
    [Parameter] public EventCallback OnInsert { get; set; }
    [Parameter] public short SelectedBasket { get; set; }

    private short SelectedCart { get; set; }
    private bool ManualChangePrice { get; set; } = false;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        SetTotalPrice();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (BasketTabVMs is null)
            BasketTabVMs = new List<PaymentTabVM>();
    }

    void SetTotalPrice()
    {
        PaymentItemCartVM.TotalPrice = Math.Round(((PaymentItemCartVM.SalePrice * (decimal)PaymentItemCartVM.QuantityInCart)
            + (PaymentItemCartVM.SalePrice * PaymentItemCartVM.Kdv / 100) + (PaymentItemCartVM.SalePrice * PaymentItemCartVM.Profit / 100)), 2);


    }
    void PriceChange()
    {
        PaymentItemCartVM.TotalPrice = PaymentItemCartVM.SalePrice * PaymentItemCartVM.QuantityInCart;

    }
    async Task UpdateCart()
    {
        PaymentItemCartVM.IsModifying = false;
        var basket = BasketTabVMs[SelectedBasket - 1];

        basket.CalculatePrices();

        await OnInsert.InvokeAsync();
        await LayoutValue.CloseModal("ProductCartDetail");
    }




    async Task InsertCart(short selectedBasket)
    {
        try
        {
            if (BasketTabVMs is not null && BasketTabVMs.ElementAtOrDefault(selectedBasket - 1) is not null
                && BasketTabVMs.ElementAtOrDefault(selectedBasket - 1).BasketItems is not null && selectedBasket != 0)
            {
                var selectedBasketResponse = BasketTabVMs.ElementAt(selectedBasket - 1);
                selectedBasketResponse.BasketItems.Add(PaymentItemCartVM);
                selectedBasketResponse.CalculatePrices();
            }
            else
            {
                BasketTabVMs.Add(new PaymentTabVM
                {
                    BasketItems = new List<PaymentItemVM> { PaymentItemCartVM },
                    IsCartActive = true,
                    PaymentAmount = PaymentItemCartVM.TotalPrice,
                    TotalPrice = PaymentItemCartVM.TotalPrice,
                    TotalDiscount = 0,
                    TotalTax = (PaymentItemCartVM.SalePrice * PaymentItemCartVM.Kdv / 100) * PaymentItemCartVM.QuantityInCart,
                    TotalPriceAfterDiscount = 0
                });
            }

            await OnInsert.InvokeAsync();
            await LayoutValue.CloseModal("ProductCartDetail");
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Sepete eklenirken bir hata oluştu.", MessageType.Error);
        }
    }

}
