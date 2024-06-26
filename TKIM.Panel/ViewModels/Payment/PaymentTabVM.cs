﻿using System.Text.Json.Serialization;
using TKIM.Panel.ViewModels.PaymentItems;

namespace TKIM.Panel.ViewModels.Payment;

public record PaymentTabVM
{
    public List<PaymentItemVM> BasketItems { get; set; } = new List<PaymentItemVM>();
    public decimal TotalPrice { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalTax { get; set; }


    [JsonIgnore]
    public bool IsCartActive { get; set; } = true;

    public void CalculatePrices()
    {
        this.TotalPrice = 0;
        this.TotalDiscount = 0;
        this.TotalTax = 0;

        BasketItems.ForEach(x =>
        {
            TotalPrice += ((x.SalePrice * x.Kdv / 100) + (x.SalePrice * x.Profit / 100) + x.SalePrice) * x.QuantityInCart;

            TotalTax += x.SalePrice * x.Kdv / 100 * x.QuantityInCart;
        });
        this.PaymentAmount = TotalPrice;
    }
}
