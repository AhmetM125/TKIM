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
                Image = file.Base64.ConvertBase64ToBinary(),
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

    
}
