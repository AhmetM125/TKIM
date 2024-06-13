using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Pages.Product;

public partial class CreateProduct : RazorComponentBase
{
    private bool HasBestUsageDate { get; set; } = false;
    private bool IsImageGalleryActive { get; set; } = false;
    private CategoryInsertRequest Model = new CategoryInsertRequest();
    private List<CategoryDropdownResponse>? Categories;

    [Inject] private ICategoryService _categoryService { get; set; }


    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadDropdowns();
    }
    async Task Submit()
    {
        var fileBytes = await JsRuntime.InvokeAsync<byte[]>("getFileBytes", "file-product");
    }
    async Task LoadDropdowns()
    {
        await LoadCategoryDropdown();
    }
    async Task LoadCategoryDropdown()
    {
        try
        {
            Categories = await _categoryService.GetCategoryForDropdown();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Kategori bilgileri yüklenirken bir hata oluştu.", MessageType.Error);
        }
    }
    //async Task FileInput()
    //{
    //    if (IsImageGalleryActive)
    //         await JsRuntime.InvokeAsync<bool>("setImageGallery", "file-product", "image-gallery");
    //}


}
