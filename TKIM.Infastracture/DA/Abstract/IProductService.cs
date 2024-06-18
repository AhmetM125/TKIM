﻿using TKIM.Dto.File;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface IProductService
{
    Task<Guid> CreateAsync(Product product,List<FileDetail> files,CancellationToken cancellationToken);
    Task<Product> GetProductById(Guid id);
    Task<List<Product>> GetProductList(CancellationToken cancellationToken);
    Task<(List<Product>,int)> GetProductListForPos(string? searchText, int currentPage,CancellationToken cancellationToken);
}
