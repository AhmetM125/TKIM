using TKIM.Panel.ViewModels.Payment;
using TKIM.Panel.ViewModels.Receipt;

namespace TKIM.Panel.Services.Abstract;

public interface IInvoiceService
{
    Task FetchInvoice(PaymentTabVM payment);
    Task<List<InvoiceHistory>> GetListInvoiceHistory();
}
