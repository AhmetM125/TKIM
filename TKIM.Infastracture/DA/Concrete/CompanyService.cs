using Microsoft.EntityFrameworkCore;
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
        company.ID = Guid.NewGuid();
        company.IS_ACTIVE = true;
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company.ID;
    }

    public async Task<List<Company>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Companies.Select(x => new Company
        {
            ADDRESS = x.ADDRESS,
            DESCRIPTION = x.DESCRIPTION,
            ID = x.ID,
            NAME = x.NAME,
            NUMBER = x.NUMBER,
            PHONE_NUMBER = x.PHONE_NUMBER,
            IS_ACTIVE = x.IS_ACTIVE
        }).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<List<Company>> GetCompanyForDropdown(CancellationToken cancellationToken)
    {
        return await _context.Companies.Where(x=>x.IS_ACTIVE)
            .Select(x => new Company
            {
                ID = x.ID,
                NAME = x.NAME
            }).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Company?> GetCompanyForModify(Guid id)
    {
        return await _context.Companies.Select(x => new Company
        {
            ADDRESS = x.ADDRESS,
            DESCRIPTION = x.DESCRIPTION,
            ID = x.ID,
            NAME = x.NAME,
            NUMBER = x.NUMBER,
            PHONE_NUMBER = x.PHONE_NUMBER,
            EMAIL = x.EMAIL

        }).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<Guid> UpdateAsync(Company company)
    {
        var companyResponse = await _context.Companies.FirstOrDefaultAsync(x => x.ID == company.ID);
        if (company != null)
        {
            companyResponse.NAME = company.NAME;
            companyResponse.DESCRIPTION = company.DESCRIPTION;
            companyResponse.ADDRESS = company.ADDRESS;
            companyResponse.PHONE_NUMBER = company.PHONE_NUMBER;
            companyResponse.NUMBER = company.NUMBER;
            companyResponse.EMAIL = company.EMAIL;
        }

        await _context.SaveChangesAsync();
        return company.ID;
    }
}
