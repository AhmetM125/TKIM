using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;

namespace TKIM.Panel.Pages.Product;

public partial class ProductPurchaseHistoryComponent : RazorComponentBase
{
    [Parameter] public Guid ProductId { get; set; }
}
