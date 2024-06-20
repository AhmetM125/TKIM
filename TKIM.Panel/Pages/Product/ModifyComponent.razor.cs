using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Pages.Product;

public partial class ModifyComponent : RazorComponentBase
{
    [Parameter] public Guid ProductId { get; set; }
    [Parameter] public EventCallback OnUpdateProduct { get; set; }
    [Inject] private IProductService? _productService { get; set; }
    private ProductModifyResponse? productResponse;
    private ProductModalType modalType = ProductModalType.Detail;


    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        //if (ProductId != Guid.Empty)
        //    productResponse = await _productService.GetProductById(ProductId);
        //StateHasChanged();
    }
    public string IsSelectedPage(ProductModalType type)
        => type != modalType ? "btn btn-outline-primary" : "btn btn-primary";

    public void ChangeModalType(ProductModalType type)
     => modalType = type;
    private async Task UpdateGrid()
    {
        await OnUpdateProduct.InvokeAsync();
    }
}
public enum ProductModalType
{
    Detail,
    SaleHistory,
    PurchaseHistory,
}
