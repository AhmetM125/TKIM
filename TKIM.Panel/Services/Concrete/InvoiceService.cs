using Microsoft.Win32.SafeHandles;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.Payment;
using TKIM.Panel.ViewModels.Receipt;

namespace TKIM.Panel.Services.Concrete;

public class InvoiceService : BaseService, IInvoiceService
{
    public InvoiceService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/Invoice";
    }

    public Task FetchInvoice(PaymentTabVM payment)
    {
        throw new NotImplementedException();
    }

    public async Task<List<InvoiceHistory>?> GetListInvoiceHistory()
        => await HandleReadResponse<List<InvoiceHistory>>("GetInvoiceHistory");
}
