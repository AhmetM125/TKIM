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

    public async Task<CategoryModifyVM?> GetCategoryForModify(Guid id)
    => await HandleReadResponse<CategoryModifyVM>($"get/modify/{id}");

    public async Task ChangeCategoryStatus(Guid id)
    => await HandlePutResponse($"ChangeInUse/{id}");

    public async Task UpdateCategory(CategoryModifyVM model)
    => await HandlePutResponse($"Update", model);

    public async Task<List<CategoryDropdownResponse>?> GetCategoryForDropdown()
        => await HandleReadResponse<List<CategoryDropdownResponse>>($"dropdown");
}
