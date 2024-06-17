namespace TKIM.Panel.ViewModels.Product;

public record ProductListPosResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? Quantity { get; set; } = 0;
    public decimal? PurchasePrice { get; set; } = 0;
    public decimal? SalePrice { get; set; } = 0;

}
