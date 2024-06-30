using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface IInvoiceService
{
    Task<List<Invoice>> GetInvoiceHistoryList();
    Task InsertInvoce(Invoice invoice);
    Task<int> InvoiceCount();
}
