using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.ViewModels.Sale;

public record BasketTabVM
{
    public List<ProductSaleCartVM> BasketItems { get; set; } = new List<ProductSaleCartVM>();
    public decimal TotalPrice
    {
        get { return BasketItems.Sum(x => x.TotalPrice); }
        set
        {
            this.TotalPrice = value;
        }
    }
    public decimal PaymentAmount
    {
        get { return BasketItems.Sum(x => x.TotalPrice); }
        set
        {
            this.PaymentAmount = value;
        }
    }

    public decimal TotalDiscount
    {
        get { return BasketItems.Sum(x => x.Discount); }
        set { this.TotalDiscount = value; }
    }
    public decimal TotalPriceAfterDiscount
    {
        get { return TotalPrice - TotalDiscount; }
        set { this.TotalPriceAfterDiscount = value; }
    }
    public decimal TotalTax
    {
        get
        {
            decimal totalTaxSummation = decimal.Zero;
            BasketItems.Aggregate(totalTaxSummation, (total, item) => total += (item.TotalPrice * item.Kdv / 100));
            return totalTaxSummation;
        }
        set { this.TotalTax = value; }

    }
    public decimal TotalPriceAfterTax
    {
        get { return TotalPriceAfterDiscount + TotalTax; }
        set { this.TotalPriceAfterTax = value; }
    }

    public bool IsCartActive { get; set; } = true;


}


