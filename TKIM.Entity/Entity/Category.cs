using System.Security.Cryptography.X509Certificates;

namespace TKIM.Entity.Entity;

public class Category : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string DESCRIPTION { get; set; }
    public bool IS_ACTIVE { get; set; }
    public List<Product> Products { get; set; }
}
