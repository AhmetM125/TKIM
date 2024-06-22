using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.BaseResponse;
using TKIM.Panel.ViewModels.Product;
using TKIM.Panel.ViewModels.Sale;

namespace TKIM.Panel.Pages.Sale;

public partial class IndexComponent : RazorComponentBase
{
    private BasketTabVM BasketTabVM { get; set; } = new BasketTabVM();
    private string SearchText { get; set; } = "";
    private List<ProductListPosResponse>? ProductList;
    private ProductSaleCartVM SelectedProduct = new ProductSaleCartVM();
    private List<BasketTabVM> BasketTabVMs { get; set; } = new List<BasketTabVM>();
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
    => BasketTabVMs = new List<BasketTabVM>();

    private void CreateNewCart()
    => BasketTabVMs.Add(new BasketTabVM { });

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
            SelectedProduct = new ProductSaleCartVM();
            var product = ProductList.FirstOrDefault(x => x.Id == productId);
            if (product is not null)
            {
                SelectedProduct = new ProductSaleCartVM
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

    async Task PaymentModal(BasketTabVM basketTab)
    {
        BasketTabVM = basketTab;
        await LayoutValue.OpenModal("PaymentSection");
    }

    private async Task ChangeProductForDetailModal(ProductSaleCartVM productDetail,short basket)
    {
        SelectedProduct = productDetail;
        SelectedBasket = basket;
        await LayoutValue.OpenModal("ProductCartDetail");
    }
}
