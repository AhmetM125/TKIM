using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;

namespace TKIM.Panel.Pages.Product;

public partial class ProductDetailComponent : RazorComponentBase
{
    [Parameter] public Guid ProductId { get; set; }
    private string ShakeCss = "";

    private async void CalculatePrice()
    {
        ShakeCss = "shake";

        // Calculate price

        await Task.Delay(1000);
        ShakeCss = "";
        StateHasChanged();
    }

}
