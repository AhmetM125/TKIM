using Microsoft.EntityFrameworkCore;
using TKIM.Dto.File;
using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.Database.Context;
using TKIM.Utils.Image;

namespace TKIM.Infastracture.DA.Concrete;

public class ProductService : IProductService
{
    private readonly TKIM_DbContext _context;

    public ProductService(TKIM_DbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Product product, List<FileDetail> files, CancellationToken cancellationToken)
    {
        product.ID = Guid.NewGuid();

        var productImages = new List<ProductImage>();

        foreach (var file in files)
        {
            var productImage = new ProductImage
            {
                ID = Guid.NewGuid(),
                PRODUCT_ID = product.ID,
                Image = Base64ToBinary.ConvertBase64ToBinary(file.Base64),
                ImageSize = file.ToString(),
                ImageType = file.Type
            };
            productImages.Add(productImage);
        }

        product.ProductImages = productImages;

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product.ID;
    }

    public async Task<List<Product>> GetProductList(CancellationToken cancellationToken)
    {
        return await _context.Products.Select(x => new Product
        {
            ID = x.ID,
            NAME = x.NAME,
            DESCRIPTION = x.DESCRIPTION,
            PRICE = x.PRICE,
            STOCK = x.STOCK
        }).AsNoTracking().ToListAsync();
    }

    public async Task<(List<Product>, int)> GetProductListForPos(string? searchText, int currentPage, CancellationToken cancellationToken)
    {
        var skip = (currentPage - 1) * 10;
        var take = 10;

        var query = _context.Products.Where(x =>  !string.IsNullOrEmpty(searchText) ? x.NAME.ToLower().Contains(searchText.ToLower()) : true)
              .Select(x => new Product
              {
                  ID = x.ID,
                  NAME = x.NAME,
                  DESCRIPTION = x.DESCRIPTION,
                  PRICE = x.PRICE,
                  STOCK = x.STOCK
              }).Skip(skip).Take(take).AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);
        var data = await query.ToListAsync(cancellationToken);
        return (data, totalCount);
    }
}
