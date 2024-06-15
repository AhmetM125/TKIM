namespace TKIM.Panel.ViewModels.Product;

public record ProductListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }

}
