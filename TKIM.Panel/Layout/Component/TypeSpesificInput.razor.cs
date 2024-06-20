using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Layout.Component;

public partial class TypeSpesificInput : RazorComponentBase
{
    [Parameter] public string Type { get; set; }
    [Parameter] public decimal DecimalValue { get; set; }
    [Parameter] public string Css { get; set; }
    [Parameter] public bool IsSalePrice { get; set; } = false;
    [Parameter] public ProductModifyResponse Product { get; set; }

    [Parameter] public EventCallback<decimal> DecimalValueChanged { get; set; }


    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
    }

    private async Task OnValueChanged(ChangeEventArgs e)
    {
        if (decimal.TryParse(e.Value.ToString(), out var newValue))
        {
            DecimalValue = newValue;
            await DecimalValueChanged.InvokeAsync(newValue);
        }
        if (!IsSalePrice)
            Product.SalePrice = Product.PurchasePrice + (Product.PurchasePrice * Product.Profit / 100) + (Product.PurchasePrice * Product.Kdv / 100);
    }
}
