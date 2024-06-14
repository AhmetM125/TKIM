using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Company;

namespace TKIM.Panel.Pages.Company;

public partial class ModifyComponent : RazorComponentBase
{
    [Parameter] public Guid CompanyId { get; set; }
    [Parameter] public EventCallback OnSubmit { get; set; }
    [Inject] private ICompanyService _companyService { get; set; }
    private CompanyModifyRequest Company { get; set; }



    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        if (CompanyId != Guid.Empty)
            await GetCompany();
        StateHasChanged();
    }
    private async Task CloseModal()
     => await LayoutValue.CloseModal("CompanyModifyModal");

    private async Task GetCompany()
    {
        try
        {
            Company = await _companyService.GetCompanyForModify(CompanyId);
        }
        catch (Exception)
        {

        }
    }

    private async Task Submit()
    {
        try
        {
            await _companyService.ModifyCompany(Company);
            await CloseModal();
            await OnSubmit.InvokeAsync();
            LayoutValue.ShowMessage("Company has been modified successfully.", MessageType.Success);
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while modifying the company.", MessageType.Error);
        }
    }

}
