using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Services.Abstract;

public interface ICategoryService
{
    Task CreateCategory(CategoryInsertRequest request);
    Task<List<CategoryListResponse>?> GetAllCategory();
}
