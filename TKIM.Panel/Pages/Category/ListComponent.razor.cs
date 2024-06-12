using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Pages.Category;

public partial class ListComponent : RazorComponentBase
{
    [Inject] private ICategoryService _categoryService { get; set; }
    private List<CategoryListResponse>? Categories;
    private Guid SelectedEmployeeId = Guid.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Categories == null)
            await LoadData();
    }
    async Task LoadData()
    {
        try
        {
            ShowLoader = true;
            Categories = await _categoryService.GetAllCategory();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading data", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }

    async Task Modify(Guid id)
    {
        //var response = await _categoryService.GetCategoryForModify(id);
        SelectedEmployeeId = id;
        await LayoutValue.OpenModal("CategoryModalId");
    }
    async Task ChangeStatus(Guid id)
    {
        try
        {
            ShowLoader = true;
            await _categoryService.ChangeCategoryStatus(id);
            await LoadData();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading data", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }
}
