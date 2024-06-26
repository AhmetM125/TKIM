using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
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
            if (string.IsNullOrEmpty(file.Base64))
                continue;

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

        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product.ID;
    }

    public async Task<Product?> GetProductById(Guid id)
        => await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);


    public async Task<List<Product>> GetProductList(CancellationToken cancellationToken)
    {
        return await _context.Products.Select(x => new Product
        {
            ID = x.ID,
            NAME = x.NAME,
            DESCRIPTION = x.DESCRIPTION,
            SALE_PRICE = x.SALE_PRICE,
            STOCK = x.STOCK
        }).AsNoTracking().ToListAsync(cancellationToken);
    }
    public async Task UpdateProductAsync(Product product, CancellationToken cancellation)
    {
        var productResponse = await _context.Products.FirstOrDefaultAsync(x => x.ID == product.ID);

        if (productResponse is null)
            throw new Exception("Product not found");

        productResponse.Update(product);

        _context.Update(productResponse);
        await _context.SaveChangesAsync(cancellation);
    }


    public async Task<Dictionary<Guid, Product>> GetProductListForPaymentSection(IEnumerable<Guid> enumerable)
    {
        var responseProduct = await _context.Products.Where(x => enumerable.Contains(x.ID)).ToListAsync();
        var dictionary = new Dictionary<Guid, Product>();
        responseProduct.ForEach(x => { dictionary.Add(x.ID, x); });
        return dictionary;
    }


    public async Task<(List<Product>, int)> GetProductListForPos(string? searchText, int currentPage, CancellationToken cancellationToken)
    {
        var skip = (currentPage - 1) * 10;
        var take = 10;

        // Base query to apply filtering
        var baseQuery = _context.Products
            .Where(x => string.IsNullOrEmpty(searchText) || x.NAME.ToLower().Contains(searchText.ToLower()));

        // Combined query to fetch both paginated data and total count
        var query = baseQuery
            .OrderBy(x => x.NAME)
            .Skip(skip)
            .Take(take)
            .Select(x => new
            {
                Product = new Product
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    DESCRIPTION = x.DESCRIPTION,
                    SALE_PRICE = x.SALE_PRICE,
                    STOCK = x.STOCK,
                    KDV = x.KDV,
                    PROFIT = x.PROFIT,
                    PURCHASE_PRICE = x.PURCHASE_PRICE,
                },
                TotalCount = baseQuery.Count() // Subquery to get the total count
            })
            .AsNoTracking();

        // Execute the query and fetch the results
        var result = await query.ToListAsync(cancellationToken);

        // Extract the data and the total count
        var data = result.Select(r => r.Product).ToList();
        var totalCount = result.FirstOrDefault()?.TotalCount ?? 0;

        return (data, totalCount);
    }

}
