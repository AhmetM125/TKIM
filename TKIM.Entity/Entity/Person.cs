namespace TKIM.Entity.Entity;

public class Person : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string SURNAME { get; set; }
    public string EMAIL { get; set; }
    public string PHONE { get; set; }
    public string ROLE { get; set; }
    // S = Super Admin , A = Admin , E = Employee

    public Security Security { get; set; }
    public Guid SECURITY_ID { get; set; }


}
