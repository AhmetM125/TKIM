using TKIM.Panel.Pages.Product;
using TKIM.Panel.Pages.Sale;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.ViewModels.Sale;

public record  BasketTabVM
{
    public List<ProductSaleCartVM> BasketItems { get; set; } = new List<ProductSaleCartVM>();
    public decimal TotalPrice { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalPriceAfterDiscount { get; set; }
    public decimal TotalTax { get; set; }
    public decimal TotalPriceAfterTax { get; set; }
    public bool IsCartActive { get; set; } = true;


}


