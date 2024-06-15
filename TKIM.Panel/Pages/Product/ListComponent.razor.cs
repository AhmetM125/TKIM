using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Pages.Product;

public partial class ListComponent : RazorComponentBase
{
    [Inject] private IProductService _productService { get; set; }
    private List<ProductListResponse>? ProductList { get; set; }

    private Guid SelectedProductId { get; set; } = Guid.Empty;



    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (ProductList is null)
            await LoadGrid();
    }
    private async Task LoadGrid()
    {
        try
        {
            ShowLoader = true;
            ProductList = await _productService.GetProductList();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading the product list.", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }
    async Task Modify(Guid id)
    {
        SelectedProductId = id;
        await LayoutValue.OpenModal("ProductModify");
    }


}
