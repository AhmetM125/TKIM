using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.ViewModels.Sale;

public record BasketTabVM
{
    public List<ProductSaleCartVM> BasketItems { get; set; } = new List<ProductSaleCartVM>();
    public decimal TotalPrice { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalPriceAfterDiscount { get; set; }
    public decimal TotalTax { get; set; }
    public bool IsCartActive { get; set; } = true;

    public void CalculatePrices()
    {
        this.TotalPrice = 0;
        this.TotalDiscount = 0;
        this.TotalPriceAfterDiscount = 0;
        this.TotalTax = 0;

        BasketItems.ForEach(x =>
        {
                TotalPrice += ((x.SalePrice * x.Kdv / 100) + (x.SalePrice * x.Profit / 100) + x.SalePrice) * x.QuantityInCart;
           
            TotalTax += x.SalePrice * x.Kdv / 100 * x.QuantityInCart;
        });
        this.PaymentAmount = TotalPrice;
    }
}


