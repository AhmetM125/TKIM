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

            throw;
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

    private async void CalculatePrice()
    {
        ShakeCss = "shake";

        // Calculate price

        await Task.Delay(1000);
        ShakeCss = "";
        StateHasChanged();
    }

}
