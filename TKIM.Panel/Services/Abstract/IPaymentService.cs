using TKIM.Panel.ViewModels.Payment;
using TKIM.Panel.ViewModels.PaymentItems;

namespace TKIM.Panel.Services.Abstract;

public interface IPaymentService
{
    Task SubmitPaymentAsync(PaymentTabVM paymentTab);
}
