using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.DA.Concrete;

public class CompanyService : ICompanyService
{
    private readonly TKIM_DbContext _context;

    public CompanyService(TKIM_DbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Company company)
    {
        company.ID = new Guid();
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company.ID;
    }
}
