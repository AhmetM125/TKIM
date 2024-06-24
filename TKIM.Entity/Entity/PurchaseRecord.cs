namespace TKIM.Entity.Entity;

public class PurchaseRecord : BaseEntity
{
    public Guid ID { get; set; }
    public Guid PRODUCT_ID { get; set; }
    public Product Product { get; set; }

    public ushort QUANTITY_CURRENT { get; set; }
    public ushort QUANTITY_AFTER { get; set; }
    public ushort QUANTITY_PURCHASED { get; set; }

    public decimal PURCHASE_PRICE_BEFORE { get; set; }
    public decimal PURCHASE_PRICE { get; set; }
    public decimal PURCHASE_PRICE_EDITED { get; set; }

    public decimal TAX_BEFORE { get; set; }
    public decimal TAX { get; set; }
    public decimal TAX_EDITED { get; set; }

    public decimal TOTAL { get; set; }
    public decimal TOTAL_EDITED { get; set; }

    public decimal PROFIT { get; set; }
    public decimal PROFIT_EDITED { get; set; }

    public decimal SALE_PRICE { get; set; }
    public decimal SALE_PRICE_EDITED { get; set; }

}
