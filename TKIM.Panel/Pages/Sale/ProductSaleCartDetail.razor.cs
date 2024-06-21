using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Layout.Component;
using TKIM.Panel.ViewModels.Product;
using TKIM.Panel.ViewModels.Sale;

namespace TKIM.Panel.Pages.Sale;

public partial class ProductSaleCartDetail : RazorComponentBase
{
    [Parameter] public ProductSaleCartVM ProductSaleCartVM { get; set; }
    [Parameter] public List<BasketTabVM> BasketTabVMs { get; set; }
    [Parameter] public EventCallback OnInsert { get; set; }
    [Parameter] public short SelectedBasket { get; set; }

    private short SelectedCart { get; set; }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        SetTotalPrice();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (BasketTabVMs is null)
            BasketTabVMs = new List<BasketTabVM>();
    }

    void SetTotalPrice()
    {
        ProductSaleCartVM.TotalPrice = ((ProductSaleCartVM.SalePrice * (decimal)ProductSaleCartVM.QuantityInCart)
            + (ProductSaleCartVM.SalePrice * ProductSaleCartVM.Kdv / 100) + (ProductSaleCartVM.SalePrice * ProductSaleCartVM.Profit / 100));
    }
    void PriceChange()
    {
        ProductSaleCartVM.TotalPrice = ProductSaleCartVM.SalePrice * ProductSaleCartVM.QuantityInCart;
    }
    async Task UpdateCart()
    {
        ProductSaleCartVM.IsModifying = false;
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
                selectedBasketResponse.BasketItems.Add(ProductSaleCartVM);
                selectedBasketResponse.CalculatePrices();
            }
            else
            {
                BasketTabVMs.Add(new BasketTabVM
                {
                    BasketItems = new List<ProductSaleCartVM> { ProductSaleCartVM },
                    IsCartActive = true,
                    PaymentAmount = ProductSaleCartVM.TotalPrice,
                    TotalPrice = ProductSaleCartVM.TotalPrice,
                    TotalDiscount = 0,
                    TotalTax = (ProductSaleCartVM.SalePrice * ProductSaleCartVM.Kdv / 100) * ProductSaleCartVM.QuantityInCart,
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
