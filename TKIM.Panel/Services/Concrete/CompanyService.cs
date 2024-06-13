using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.Company;

namespace TKIM.Panel.Services.Concrete;

public class CompanyService : BaseService, ICompanyService
{
    public CompanyService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/Company";
    }

    public async Task CreateCompany(CompanyInsertRequest request)
    => await HandlePostResponse($"Create", request);
}
