namespace TKIM.Entity.Entity;

public class Product : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public decimal PRICE { get; set; }
    public string DESCRIPTION { get; set; }
    public byte[] IMAGE { get; set; }
    public string BARCODE { get; set; }
    public int STOCK { get; set; }
    public decimal TAX { get; set; }

    public List<Invoice> Invoices { get; set; }
    public Guid CATEGORY_ID { get; set; }
    public Category Category { get; set; }
}
