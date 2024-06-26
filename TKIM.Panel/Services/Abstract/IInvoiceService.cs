using TKIM.Panel.ViewModels.Payment;

namespace TKIM.Panel.Services.Abstract;

public interface IInvoiceService
{
    Task FetchInvoice(PaymentTabVM payment);
}
