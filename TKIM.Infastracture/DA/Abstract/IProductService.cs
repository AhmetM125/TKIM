using TKIM.Dto.File;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface IProductService
{
    Task<Guid> CreateAsync(Product product,List<FileDetail> files,CancellationToken cancellationToken);
    Task<List<Product>> GetProductList(CancellationToken cancellationToken);
}
