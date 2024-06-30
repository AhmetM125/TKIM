             namespace TKIM.Dto.InvoiceGenerate;

// this is only will be use to generate client for invoice but i dont save it to database i will handle to save database later
public record InvoiceGenerateDto
{
    public List<Product> BasketItems { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalTax { get; set; }
}

public record Product
{
    public string Name { get; set; }
    public decimal SalePrice { get; set; }
    public int QuantityInCart { get; set; } 
    public decimal TotalPrice { get; set; } = 0;
    public decimal Kdv { get; set; } = 0;
}
