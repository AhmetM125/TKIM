namespace TKIM.Entity.Entity;

public class Product : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string? DESCRIPTION { get; set; }
    public string? BARCODE { get; set; }
    public int STOCK { get; set; }
    public decimal KDV { get; set; }
    public decimal PURCHASE_PRICE { get; set; }
    public decimal SALE_PRICE { get; set; }
    public decimal PROFIT { get; set; }
    public Guid? COMPANY_ID { get; set; }
    public Company Company { get; set; }
    public Guid? CATEGORY_ID { get; set; }
    public Category Category { get; set; }

    public List<ProductImage> ProductImages { get; set; }
    public IEnumerable<PaymentItems> PaymentItems { get; set; }
    public IEnumerable<PurchaseRecord> PurchaseRecords { get; set; }
    public IEnumerable<SaleRecord> SaleRecords { get; set; }

    public void Update(Product product)
    {
        NAME = product.NAME;
        DESCRIPTION = product.DESCRIPTION;
        BARCODE = product.BARCODE;
        STOCK = product.STOCK;
        KDV = product.KDV;
        PURCHASE_PRICE = product.PURCHASE_PRICE;
        SALE_PRICE = product.SALE_PRICE;
        PROFIT = product.PROFIT;
        COMPANY_ID = product.COMPANY_ID;
        CATEGORY_ID = product.CATEGORY_ID;
    }
}
