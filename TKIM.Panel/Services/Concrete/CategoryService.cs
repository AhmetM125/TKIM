using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.Category;

namespace TKIM.Panel.Services.Concrete;

public class CategoryService : BaseService, ICategoryService
{
    public CategoryService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/Category";
    }

    public async Task CreateCategory(CategoryInsertRequest request)
     => await HandlePostResponse($"Create", request);

    public async Task<List<CategoryListResponse>?> GetAllCategory()
     => await HandleReadResponse<List<CategoryListResponse>>($"get/all");
}
