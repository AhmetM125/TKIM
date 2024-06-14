using TKIM.Panel.ViewModels.Company;

namespace TKIM.Panel.Services.Abstract;

public interface ICompanyService
{
    Task CreateCompany(CompanyInsertRequest request);
    Task<List<CompanyListResponse>?> GetAllCompanies();
    Task<CompanyModifyRequest?> GetCompanyForModify(Guid companyId);
    Task ModifyCompany(CompanyModifyRequest company);
    Task<List<CompanyDropdownResponse>?> GetCompanyForDropdown();
}
