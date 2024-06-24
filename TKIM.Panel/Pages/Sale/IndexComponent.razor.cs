using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.BaseResponse;
using TKIM.Panel.ViewModels.Payment;
using TKIM.Panel.ViewModels.PaymentItems;
using TKIM.Panel.ViewModels.Product;
using TKIM.Panel.ViewModels.Sale;

namespace TKIM.Panel.Pages.Sale;

public partial class IndexComponent : RazorComponentBase
{
    private PaymentTabVM PaymentTabVM { get; set; } = new PaymentTabVM();
    private string SearchText { get; set; } = "";
    private List<ProductListPosResponse>? ProductList;
    private PaymentItemVM SelectedProduct = new PaymentItemVM();
    private List<PaymentTabVM> BasketTabVMs { get; set; } = new List<PaymentTabVM>();
    private Guid SelectedProductIdForDetail { get; set; }
    private int CurrentPage { get; set; } = 1;
    private short SelectedBasket { get; set; } = 0;



    [Inject] IProductService _productService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadGrid();
    }
    private void ChangePage(PageType pageType)
    => PageType = pageType;


    async Task LoadGrid()
    {
        try
        {
            ShowLoader = true;

            var response = await _productService.ProductListForPos(SearchText, CurrentPage);
            ProductList = response.Data.List;
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Ürünler yüklenirken bir hata oluştu.", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }

    async Task SearchProduct(ChangeEventArgs e)
    {
        if (e is not null && e.Value is not null && e.Value.ToString().Length % 2 == 0 || e.Value.ToString().Length == 0)
        {
            SearchText = e.Value.ToString();
            await LoadGrid();
        }
    }

    private void ClearCarts()
    => BasketTabVMs = new List<PaymentTabVM>();

    private void CreateNewCart()
    => BasketTabVMs.Add(new PaymentTabVM { });

    private async Task ProductDetails(Guid productId)
    {
        try
        {
            SelectedProductIdForDetail = productId;
            await LayoutValue.OpenModal("ProductDetail");
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Ürün detayları yüklenirken bir hata oluştu.", MessageType.Error);
        }

    }

    private string IsButtonActive(PageType pageType)
     => PageType != pageType ? "btn-outline-primary" : "btn-primary";
    async Task AddCart(Guid productId)
    {
        try
        {
            SelectedProduct = new PaymentItemVM();
            var product = ProductList.FirstOrDefault(x => x.Id == productId);
            if (product is not null)
            {
                SelectedProduct = new PaymentItemVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    SalePrice = product.SalePrice,
                    PurchasePrice = product.PurchasePrice ,
                    Stock = product.Quantity ,
                    QuantityInCart = 1
                };
                await LayoutValue.OpenModal("ProductCartDetail");
            }
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Ürün seçilirken bir hata oluştu.", MessageType.Error);
        }

    }

    async Task PaymentModal(PaymentTabVM paymentTab)
    {
        PaymentTabVM = paymentTab;
        await LayoutValue.OpenModal("PaymentSection");
    }

    private async Task ChangeProductForDetailModal(PaymentItemVM productDetail,short basket)
    {
        SelectedProduct = productDetail;
        SelectedBasket = basket;
        await LayoutValue.OpenModal("ProductCartDetail");
    }
}
