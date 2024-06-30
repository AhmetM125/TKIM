using Microsoft.AspNetCore.Components;
using TKIM.Panel.Base;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.ViewModels.Receipt;

namespace TKIM.Panel.Pages.Sale;

public partial class SaleHistory : RazorComponentBase
{
    private List<InvoiceHistory> InvoiceHistories { get; set; }
    [Inject] private IInvoiceService _invoiceService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadGrid();
    }

    async Task LoadGrid()
    {
        try
        {
            ShowLoader = true;

            var response = await _invoiceService.GetInvoiceHistory();
            InvoiceHistories = response.Data.List;
        }
        catch (Exception)
        {
            LayoutValue.ShowMessage("Fatura geçmişi yüklenirken bir hata oluştu.", MessageType.Error);
        }
        finally
        {
            ShowLoader = false;
        }
    }
}
