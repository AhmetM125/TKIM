namespace TKIM.Entity.Entity;

public class Invoice : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string INVOICE_NUMBER { get; set; }
    public DateTime INVOICE_DATE { get; set; }
    public decimal TOTAL { get; set; }
    public byte[] INVOICE_PDF { get; set; }
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }
    public Guid CUSTOMER_ID { get; set; }
    public Company Company { get; set; }
    public Guid COMPANY_ID { get; set; }


}
