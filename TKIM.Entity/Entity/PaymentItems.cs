namespace TKIM.Entity.Entity;

public class PaymentItems : BaseEntity
{
    public Guid ID { get; set; }

    public SaleRecord SaleRecord { get; set; }
    public Guid SALE_RECORD_ID { get; set; }

    public PurchaseRecord  PurchaseRecord{ get; set; }
    public Guid PURCHASE_RECORD_ID { get; set; }

    public Payment Payment { get; set; }
    public Guid PAYMENT_ID { get; set; }

}
