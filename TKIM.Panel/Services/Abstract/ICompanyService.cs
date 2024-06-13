using TKIM.Panel.ViewModels.Company;

namespace TKIM.Panel.Services.Abstract;

public interface ICompanyService
{
    Task CreateCompany(CompanyInsertRequest request);
}
