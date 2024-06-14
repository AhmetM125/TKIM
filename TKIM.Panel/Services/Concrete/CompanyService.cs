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

    public async Task<List<CompanyListResponse>?> GetAllCompanies()
        => await HandleReadResponse<List<CompanyListResponse>>($"Get/All");

    public async Task<CompanyModifyRequest?> GetCompanyForModify(Guid companyId)
        => await HandleReadResponse<CompanyModifyRequest>($"Get/Modify/{companyId}");

    public async Task ModifyCompany(CompanyModifyRequest company)
    => await HandlePutResponse($"Modify", company);

    public async Task<List<CompanyDropdownResponse>?> GetCompanyForDropdown()
    => await HandleReadResponse<List<CompanyDropdownResponse>>($"dropdown");
}
