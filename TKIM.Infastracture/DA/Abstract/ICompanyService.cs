using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface ICompanyService
{
    Task<Guid> CreateAsync(Company company);
    Task<List<Company>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Company>> GetCompanyForDropdown(CancellationToken cancellationToken);
    Task<Company> GetCompanyForModify(Guid id);
    Task<Guid> UpdateAsync(Company company);
}
