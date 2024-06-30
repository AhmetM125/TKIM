namespace TKIM.Panel.ViewModels.Receipt;

public record InvoiceHistory
{
    public Guid InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string CustomerFullName { get; set; }
    public string CompanyName { get; set; }
    public decimal TotalPayment { get; set; }

    public List<InvoiceProducts> InvoiceProducts { get; set; }

    public bool IsProductListActive { get; set; }

}

public record InvoiceProducts
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal SalePrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }

}
