namespace TKIM.Panel.ViewModels.Receipt;

public record InvoiceHistory
{
    public Guid InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string CustomerFullName { get; set; }
    public string CompanyName { get; set; }
    public decimal TotalPayment { get; set; }

}
