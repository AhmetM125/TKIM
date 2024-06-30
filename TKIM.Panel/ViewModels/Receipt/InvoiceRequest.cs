namespace TKIM.Panel.ViewModels.Receipt;

public record InvoiceRequest
{
    public InvoiceRequest(List<Product> basketItems, decimal totalPrice, decimal paymentAmount, decimal totalDiscount, decimal totalTax)
    {
        BasketItems = basketItems;
        TotalPrice = totalPrice;
        PaymentAmount = paymentAmount;
        TotalDiscount = totalDiscount;
        TotalTax = totalTax;
    }

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

