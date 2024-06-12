using Microsoft.JSInterop;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Pages.Product;

public partial class CreateProduct : RazorComponentBase
{
    private bool HasBestUsageDate { get; set; } = false;
    private CategoryInsertRequest Model = new CategoryInsertRequest();

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Model = new CategoryInsertRequest();
    }
    async Task Submit()
    {
        var fileBytes = await JsRuntime.InvokeAsync<byte[]>("getFileBytes", "file-product");
    }
    async Task FileInput()
    {
        var fileBytes = await JsRuntime.InvokeAsync<byte[]>("setImageGallery", "file-product", "image-gallery");
    }


}
