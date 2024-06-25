using System.Text.Json.Serialization;

namespace TKIM.Panel.ViewModels.PaymentItems;

public record PaymentItemVM
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Stock { get; set; }
    public int QuantityInCart { get; set; } = 0; // quantity that is in the cart
    public decimal TotalPrice { get; set; } = 0;
    public decimal Kdv { get; set; } = 0;
    public decimal Discount { get; set; } = 0;
    public decimal Profit { get; set; } = 0;



    [JsonIgnore]
    public bool IsModifying { get; set; } = false;
}
