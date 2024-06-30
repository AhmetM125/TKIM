using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface IPaymentItemService
{
    Task<List<PaymentItems>> GetPaymentItemListByInvoiceId(Guid invoiceId);
}
