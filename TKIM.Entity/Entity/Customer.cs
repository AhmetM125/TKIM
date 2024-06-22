namespace TKIM.Entity.Entity;

public class Customer : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string SURNAME { get; set; }
    public string ADDRESS { get; set; }
    public string PHONE_NUMBER { get; set; }
    public string CITY { get; set; }

    public IEnumerable<Invoice> Invoices { get; set; }
    public IEnumerable<Payment> Payments { get; set; }
}
