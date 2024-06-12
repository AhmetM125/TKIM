using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface ICategoryService
{
    Task<Guid> CreateAsync(Category category, CancellationToken cancellationToken);
    Task<Category> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(Category category, CancellationToken cancellationToken);
    Task ChangeCategoryStatus(Guid id);
}
