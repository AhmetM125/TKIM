namespace TKIM.Panel.ViewModels.Product;

public record ProductModifyResponse
{
    public Guid  Id { get; set; }
    public string  Name { get; set; }
    public string  Desc { get; set; }
    public string  Stock { get; set; }
    public string  Barkod { get; set; }
    public string  Category { get; set; }
    public string  Company { get; set; }
    public decimal Kdv { get; set; } = 0;
    public decimal PurchasePrice { get; set; } = 0;
    public decimal SalePrice { get; set; } = 0;     
    public decimal Profit { get; set; } = 0; 

}
