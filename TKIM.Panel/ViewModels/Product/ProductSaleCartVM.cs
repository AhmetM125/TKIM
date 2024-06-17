namespace TKIM.Panel.ViewModels.Product;

public class ProductSaleCartVM
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Stock { get; set; }
    public int QuantityInCart { get; set; } = 0; // quantity that is in the cart
    public decimal TotalPrice { get; set; }
} 
