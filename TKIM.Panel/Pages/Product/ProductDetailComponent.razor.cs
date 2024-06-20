using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Category;
using TKIM.Panel.ViewModels.Company;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Pages.Product;

public partial class ProductDetailComponent : RazorComponentBase
{
    [Parameter] public Guid ProductId { get; set; }
    [Parameter] public EventCallback OnUpdate { get; set; }
    [Inject] private IProductService _productService { get; set; }
    [Inject] private ICategoryService _categoryService { get; set; }
    [Inject] private ICompanyService _companyService { get; set; }

    private List<CategoryDropdownResponse>? Categories;
    private List<CompanyDropdownResponse>? Companies;
    private ProductModifyResponse Product;


    private string ShakeCss = "";

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Companies is null)
            await LoadCompanyDropdown();
        if (Categories is null)
            await LoadCategoryDropdown();

    }
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        if (ProductId != Guid.Empty)
            await GetProduct();
        StateHasChanged();
    }

    private async Task LoadCategoryDropdown()
    {
        try
        {
            Categories = await _categoryService.GetCategoryForDropdown();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading the category dropdown.", MessageType.Error);
        }

    }
    private async Task GetProduct()
    {
        try
        {
            Product = await _productService.GetProductById(ProductId);
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading the product.", MessageType.Error);
        }
    }
    private async Task LoadCompanyDropdown()
    {
        try
        {
            Companies = await _companyService.GetCompanyForDropdown();

        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading the company dropdown.", MessageType.Error);
        }
    }
    private async Task Update()
    {
        try
        {
            await _productService.UpdateProductAsync(Product);
            LayoutValue.ShowMessage("Product updated successfully.", MessageType.Success);
            await OnUpdate.InvokeAsync();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while updating the product.", MessageType.Error);
        }
        finally
        {
            await GetProduct();
            StateHasChanged();
        }
    }

    private async Task CalculatePrice()
    {
        if (Product.PurchasePrice == 0 || Product.Profit == 0 || Product.Kdv == 0)
        {
            LayoutValue.ShowMessage("Please enter the purchase price, profit and VAT values.", MessageType.Error);
            Product.PurchasePrice = Product.PurchasePrice == 0 ? 1 : Product.PurchasePrice;
            Product.Profit = Product.Profit == 0 ? 1 : Product.Profit;
            Product.Kdv = Product.Kdv == 0 ? 1 : Product.Kdv;
            ShakeCss = "shake";
        }
        else
            Product.SalePrice = Product.PurchasePrice + (Product.PurchasePrice * Product.Profit / 100) + (Product.PurchasePrice * Product.Kdv / 100);
        
        await Task.Delay(1000);
        ShakeCss = "";
        StateHasChanged();
    }

}
