namespace TKIM.Dto.InvoiceGenerate;

public record InvoiceGenerateDto
{
    public PaymentDetails PaymentDetails { get; set; }
}
public record PaymentDetails
{
    public List<Products> BasketItems { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalTax { get; set; }
}

public record Products
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Stock { get; set; }
    public int QuantityInCart { get; set; } = 0;
    public decimal TotalPrice { get; set; } = 0;
    public decimal Kdv { get; set; } = 0;
    public decimal Discount { get; set; } = 0;
    public decimal Profit { get; set; } = 0;
}
