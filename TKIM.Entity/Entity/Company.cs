namespace TKIM.Entity.Entity;

public class Company : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string DESCRIPTION { get; set; }
    public string ADDRESS { get; set; }
    public string PHONE_NUMBER { get; set; }
    public string NUMBER { get; set; }

    public IEnumerable<Invoice> Invoices { get; set; }

}
