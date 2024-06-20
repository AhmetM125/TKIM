namespace TKIM.Panel.ViewModels.Product;

public record ProductModifyResponse
{
    public Guid  Id { get; set; }
    public string  Name { get; set; }
    public string?  Desc { get; set; }
    public int  Stock { get; set; } = 0;
    public string?  Barkod { get; set; }
    public Guid?  Category { get; set; }
    public Guid?  Company { get; set; }
    public decimal Kdv { get; set; } = 0;
    public decimal PurchasePrice { get; set; } = 0;
    public decimal SalePrice { get; set; } = 0;     
    public decimal Profit { get; set; } = 0; 

}

