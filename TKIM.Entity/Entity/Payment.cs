namespace TKIM.Entity.Entity;

public class Payment : BaseEntity
{
    public Guid ID { get; set; }

    public List<PaymentItems> BasketItems { get; set; }

    public decimal TOTAL_PRICE { get; set; }
    public decimal TOTAL_TAX { get; set; }
    public decimal TOTAL_DISCOUNT { get; set; }
    public decimal TOTAL_PAYMENT { get; set; }
    public DateTime PAYMENT_DATE { get; set; }


    public Customer? Customer { get; set; }
    public Guid? CUSTOMER_ID { get; set; }
    public Company? Company { get; set; }
    public Guid? COMPANY_ID { get; set; }

    public Invoice Invoice { get; set; }
    public Guid INVOICE_ID { get; set; }
}
