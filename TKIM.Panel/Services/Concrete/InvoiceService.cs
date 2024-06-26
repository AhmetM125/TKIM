using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.Payment;

namespace TKIM.Panel.Services.Concrete;

public class InvoiceService :BaseService, IInvoiceService
{
    public InvoiceService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/Invoice";
    }

    public Task FetchInvoice(PaymentTabVM payment)
    {
        throw new NotImplementedException();
    }
}
