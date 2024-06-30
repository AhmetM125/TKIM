using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.ViewModels.Receipt;

namespace TKIM.Panel.Pages.Sale;

public partial class SaleHistory : RazorComponentBase
{
    [Parameter] public List<InvoiceHistory> InvoiceHistories { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }
    private async Task FetchProducts(Guid invoiceId)
    {
        var invoice = InvoiceHistories.FirstOrDefault(x => x.InvoiceId == invoiceId);
        if (invoice != null)
            invoice.IsProductListActive = !invoice.IsProductListActive;




    }
}
