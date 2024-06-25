using TKIM.Entity.Entity;

namespace TKIM.Infastracture.DA.Abstract;

public interface IPaymentService
{
    Task InsertPayment(Payment payment);
}
