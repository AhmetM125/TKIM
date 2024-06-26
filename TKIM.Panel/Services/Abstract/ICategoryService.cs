﻿using TKIM.Panel.ViewModels.Category;
using TKIM.Panel.ViewModels.Company;

namespace TKIM.Panel.Services.Abstract;

public interface ICategoryService
{
    Task CreateCategory(CategoryInsertRequest request);
    Task<List<CategoryListResponse>?> GetAllCategory();
    Task<CategoryModifyVM> GetCategoryForModify(Guid id);
    Task ChangeCategoryStatus(Guid id);
    Task UpdateCategory(CategoryModifyVM model);
    Task<List<CategoryDropdownResponse>?> GetCategoryForDropdown();
}
