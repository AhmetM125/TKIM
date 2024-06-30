using TKIM.Panel.ViewModels.Receipt;

namespace TKIM.Panel.Services.Abstract;

public interface IPaymentItemService
{
    Task<List<InvoiceProducts>?> GetPaymentItemListByInvoiceId(Guid invoiceId);
}
