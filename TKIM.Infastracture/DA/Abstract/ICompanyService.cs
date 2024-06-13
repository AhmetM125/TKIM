using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface ICompanyService
{
    Task<Guid> CreateAsync(Company company);
}
