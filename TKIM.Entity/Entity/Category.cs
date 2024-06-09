namespace TKIM.Entity.Entity;

public class Category : BaseEntity
{
    public Guid ID { get; set; }
    public string NAME { get; set; }
    public string DESCRIPTION { get; set; }
    public List<Product> Products { get; set; }
}
