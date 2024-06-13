using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Company;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TKIM.Panel.Pages.Company;

public partial class CreateComponent : RazorComponentBase
{
    private CompanyInsertRequest Model = new();

   [Inject] private ICompanyService _companyService { get; set; }


    private async Task Submit()
    {
        try
        {
            CompanyInsertRequestValidator validationRules = new();
            var validationResult = validationRules.Validate(Model);
            if (validationResult.IsValid)
            {
                await _companyService.CreateCompany(Model);
                LayoutValue.ShowMessage("Company created successfully", MessageType.Success);
            }
            else
            {
                var validationErrors = string.Join(Environment.NewLine, validationResult.Errors);
                LayoutValue.ShowMessage(validationErrors, MessageType.Error);
            }
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Beklenmedik Bir Hata Oluştu!", MessageType.Error);
        }
        finally
        {
            Model = new();
        }
    }
}
