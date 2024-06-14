namespace TKIM.Entity.Entity;

public class Company : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string DESCRIPTION { get; set; }
    public string EMAIL { get; set; }
    public string ADDRESS { get; set; }
    public string PHONE_NUMBER { get; set; }
    public string NUMBER { get; set; }
    public bool IS_ACTIVE { get; set; }

    public IEnumerable<Invoice> Invoices { get; set; }
    public IEnumerable<Product> Products { get; set; }

}
