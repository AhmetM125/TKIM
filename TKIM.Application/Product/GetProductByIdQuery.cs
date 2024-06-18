using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Product;

public record class GetProductByIdQuery : Query<ProductModifyResponse>
{
    public Guid Id { get; set; }
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }

    public override ValidationResult Validate()
    {
        return new GetProductByIdValidator().Validate(this);
    }
}

public class GetProductByIdQueryHandler : QueryHandler<GetProductByIdQuery, ProductModifyResponse>
{
    private readonly IProductService _productService;

    public GetProductByIdQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<ProductModifyResponse> ExecuteQuery(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var productResponse = await _productService.GetProductById(query.Id);
        return null;
    }
}

public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is empty");
    }
}

public record ProductModifyResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Stock { get; set; }
    public string Barkod { get; set; }
    public string Category { get; set; }
    public string Company { get; set; }
    public decimal Kdv { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Profit { get; set; }
}
