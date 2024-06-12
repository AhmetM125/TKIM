using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Pages.Category;

public partial class ModifyComponent : RazorComponentBase
{
    [Parameter] public Guid Id { get; set; }
    [Parameter] public EventCallback OnSubmit { get; set; }
    [Inject] private ICategoryService _categoryService { get; set; }
    private CategoryModifyVM Model;



    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        if (Id != Guid.Empty)
            await LoadData();
        StateHasChanged();
    }

    async Task LoadData()
    {
        try
        {
            Model = await _categoryService.GetCategoryForModify(Id);
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while loading data", MessageType.Error);
        }

    }
    async Task Submit()
    {
        try
        {
            await _categoryService.UpdateCategory(Model);
            await LoadData();
            await OnSubmit.InvokeAsync();
            await LayoutValue.CloseModal("CategoryModalId");
            LayoutValue.ShowMessage("Kategori Başarıyla Güncellenmiştir.", MessageType.Success);
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while updating data", MessageType.Error);
        }
        
    }



}
