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

    private short SelectedCart { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (BasketTabVMs is null)
            BasketTabVMs = new List<BasketTabVM>();
    }

    void SalePriceChange()
    {
        ProductSaleCartVM.TotalPrice = ((ProductSaleCartVM.SalePrice * (decimal)ProductSaleCartVM.QuantityInCart) 
            + (ProductSaleCartVM.SalePrice * ProductSaleCartVM.Kdv / 100) + (ProductSaleCartVM.SalePrice * ProductSaleCartVM.Profit / 100));
    }
    void PriceChange()
    {
        ProductSaleCartVM.TotalPrice = ProductSaleCartVM.SalePrice * ProductSaleCartVM.QuantityInCart;
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
            }
            else
            {
                BasketTabVMs.Add(new BasketTabVM
                {
                    BasketItems = new List<ProductSaleCartVM> { ProductSaleCartVM }
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
