using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Pages.Category;

public partial class CreateCategory : RazorComponentBase
{
    [Inject] private ICategoryService _categoryService { get; set; }
    private CategoryInsertRequest Category = new CategoryInsertRequest();
    async Task Submit()
    {
        try
        {
            await _categoryService.CreateCategory(Category);
            await _categoryService.GetAllCategory();
            LayoutValue.ShowMessage("Category created successfully", MessageType.Success);

        }
        catch (Exception ex)
        {
            LayoutValue.ShowMessage("Error", MessageType.Error);
            throw;
        }
    }
}
