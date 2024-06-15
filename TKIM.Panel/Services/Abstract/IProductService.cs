using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Services.Abstract;

public interface IProductService
{
    Task CreateProductAsync(ProductInsertRequest model, List<FileDetail> files,bool HasBestBeforeDate);
    Task<List<ProductListResponse>?> GetProductList();

    Task<ProductModifyResponse?> GetProductById(Guid id);
}
