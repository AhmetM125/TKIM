using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Product;

public record class GetProductListQuery : Query<IEnumerable<ProductListResponse>>
{
    public GetProductListQuery()
    {

    }

    public override ValidationResult Validate()
    {
        return new GetProductListValidator().Validate(this);
    }
}

public class GetProductListValidator : AbstractValidator<GetProductListQuery>
{
    public GetProductListValidator()
    {

    }
}

public class GetProductListQueryHandler : QueryHandler<GetProductListQuery, IEnumerable<ProductListResponse>>
{

    private readonly IProductService _productService;

    public GetProductListQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async override Task<IEnumerable<ProductListResponse>> ExecuteQuery(GetProductListQuery query, CancellationToken cancellationToken)
    {
        return (await _productService.GetProductList(cancellationToken)).Select(x =>
         new ProductListResponse(x.ID, x.NAME, x.DESCRIPTION, x.SALE_PRICE, x.STOCK));
    }

    
}


public record ProductListResponse
{
    public ProductListResponse(Guid id, string name, string description, decimal price, int? stock)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int? Stock { get; init; }

}
