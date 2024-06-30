using Azure.Core;
using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Product;

public record class GetProductListForPosQuery : Query<ProductListPosResponse>
{
    public string? SearchText { get; set; }
    public int CurrentPage { get; set; }

    public GetProductListForPosQuery(string searchText, int currentPage)
    {
        SearchText = searchText;
        CurrentPage = currentPage;
    }

    public override ValidationResult Validate()
    {
        return new ProductListForPosValidator().Validate(this);
    }
}
public class ProductListForPosValidator : AbstractValidator<GetProductListForPosQuery>
{
    public ProductListForPosValidator()
    {
        RuleFor(x => x.CurrentPage).GreaterThan(0).WithMessage("Geçerli sayfa numarası giriniz.");
    }

}
public class GetProductListForPosQueryHandler : QueryHandler<GetProductListForPosQuery, ProductListPosResponse>
{
    private readonly IProductService _productService;

    public GetProductListForPosQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async override Task<ProductListPosResponse> ExecuteQuery(GetProductListForPosQuery query, CancellationToken cancellationToken)
    {
        (List<Entity.Entity.Product> data, int totalCount) = await _productService.GetProductListForPos(query.SearchText, query.CurrentPage, cancellationToken);

        return new ProductListPosResponse(data.Select(x => new ProductListPos(x.ID, x.NAME, x.STOCK, x.PURCHASE_PRICE, x.SALE_PRICE, x.PROFIT, x.KDV)).ToList(), totalCount);
    }


}

public record class ProductListPos
{
    public ProductListPos(Guid id, string name, int quantity, decimal purchasePrice, decimal salePrice, decimal profit, decimal tax)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        Profit = profit;
        Kdv = tax;

    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Profit { get; set; }
    public decimal Kdv { get; set; }
}
public record class ProductListPosResponse
{
    public ProductListPosResponse(List<ProductListPos> data, int totalCount)
    {
        List = data;
        TotalCount = totalCount;
    }

    public List<ProductListPos> List { get; set; }
    public int TotalCount { get; set; }

}
