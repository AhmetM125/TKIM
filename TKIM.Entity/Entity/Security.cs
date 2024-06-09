namespace TKIM.Entity.Entity;

public class Security : BaseEntity
{
    public Guid ID { get; set; }
    public string USERNAME { get; set; }
    public string PASSWORD { get; set; }

    public Person Person { get; set; }

}
