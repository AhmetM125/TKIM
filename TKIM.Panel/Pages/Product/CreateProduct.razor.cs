﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Category;
using TKIM.Panel.ViewModels.Company;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Pages.Product;

public partial class CreateProduct : RazorComponentBase
{
    private bool HasBestUsageDate { get; set; } = false;
    private bool IsImageGalleryActive { get; set; } = false;
    private ProductInsertRequest Model = new ProductInsertRequest();
    private List<CategoryDropdownResponse>? Categories;
    private List<CompanyDropdownResponse>? Companies;

    [Inject] private ICategoryService _categoryService { get; set; }
    [Inject] private ICompanyService _companyService { get; set; }
    [Inject] private IProductService _productService { get; set; }


    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadDropdowns();
    }
    async Task Submit()
    {
        try
        {
            ShowLoader = true;
            // Get the files as a list of base64 strings from JavaScript
            var base64Files = await JsRuntime.InvokeAsync<List<FileDetail>>("getFileBytes", "file-product");

            // Convert base64 strings to byte arrays
            //var files = base64Files.Select(base64 => Convert.FromBase64String(base64)).ToList();

            var productInsertValidator = new ProductInsertValidator();
            var validationResult = productInsertValidator.Validate(Model);

            if (validationResult.IsValid)
            {
                await _productService.CreateProductAsync(Model, base64Files, HasBestUsageDate);
                LayoutValue.ShowMessage("Ürün başarıyla eklendi.", MessageType.Success);
            }
            else
            {
                string validationErrors = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                LayoutValue.ShowMessage(validationErrors, MessageType.Error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating product: {ex.Message}");
            LayoutValue.ShowMessage("Ürün eklenirken bir hata oluştu.", MessageType.Error);
        }
        finally
        {
            Model = new ProductInsertRequest(); // Reset the form or model
            ShowLoader = false;
        }

    }
    async Task LoadDropdowns()
    {
        await LoadCategoryDropdown();
        await LoadCompanyDropdown();
    }
    async Task LoadCategoryDropdown()
    {
        try
        {
            ShowLoader = true;
            Categories = await _categoryService.GetCategoryForDropdown();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Kategori bilgileri yüklenirken bir hata oluştu.", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }
    async Task LoadCompanyDropdown()
    {
        try
        {
            ShowLoader = true;
            Companies = await _companyService.GetCompanyForDropdown();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Firma bilgileri yüklenirken bir hata oluştu.", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }
    //async Task FileInput()
    //{
    //    if (IsImageGalleryActive)
    //         await JsRuntime.InvokeAsync<bool>("setImageGallery", "file-product", "image-gallery");
    //}


}
