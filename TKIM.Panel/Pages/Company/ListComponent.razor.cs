using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Company;

namespace TKIM.Panel.Pages.Company;

public partial class ListComponent : RazorComponentBase
{
    [Inject]
    private ICompanyService _companyService { get; set; }

    private List<CompanyListResponse>? Companies { get; set; }
    private Guid SelectedCompanyId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if(Companies == null)
            await LoadGrid();
    }
    async Task LoadGrid()
    {
        try
        {
            ShowLoader = true;
            Companies = await _companyService.GetAllCompanies();
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("An error occurred while fetching companies", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }

    async Task Modify(Guid id)
    {
        SelectedCompanyId = id;
        await LayoutValue.OpenModal("CompanyModifyModal");
    }
    async Task ChangeStatus(Guid id)
    {

    }
}
