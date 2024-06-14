namespace TKIM.Entity.Entity;

public class ProductImage :BaseEntity
{
    public Guid ID { get; set; }
    public Guid PRODUCT_ID { get; set; }
    public byte[] Image { get; set; }
    public string? ImageSize { get; set; }   
    public string? ImageType { get; set; }
    public Product Product { get; set; }
}
