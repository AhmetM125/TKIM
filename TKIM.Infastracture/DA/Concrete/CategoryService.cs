using Microsoft.EntityFrameworkCore;
using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.DA.Concrete;

public class CategoryService : ICategoryService
{
    private readonly TKIM_DbContext _context;

    public CategoryService(TKIM_DbContext context)
    {
        _context = context;
    }

    public async Task ChangeCategoryStatus(Guid id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == id);

        if (category != null)
        {
            // Toggle the IS_ACTIVE property
            category.IS_ACTIVE = !category.IS_ACTIVE;

            // Save changes asynchronously
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Guid> CreateAsync(Category category, CancellationToken cancellationToken)
    {
        category.ID = Guid.NewGuid();
        await _context.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return category.ID;
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Categories.Select(x => new Category
        {
            DESCRIPTION = x.DESCRIPTION,
            ID = x.ID,
            NAME = x.NAME,
            IS_ACTIVE = x.IS_ACTIVE
        }).AsNoTracking().OrderBy(x => x.NAME).ToListAsync(cancellationToken);
    }

    public async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id, cancellationToken) ?? new Category();
    }

    public async Task<List<Category>> GetCategoryForDropdown()
    {
        return await _context.Categories.Where(x => x.IS_ACTIVE).Select(x => new Category
        {
            ID = x.ID,
            NAME = x.NAME
        }).AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories.FirstOrDefaultAsync(x => x.ID == category.ID, cancellationToken);
        if (entity != null)
        {
            entity.NAME = category.NAME;
            entity.DESCRIPTION = category.DESCRIPTION;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
