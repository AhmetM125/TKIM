using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.Payment;

namespace TKIM.Panel.Services.Concrete;

public class PaymentService : BaseService, IPaymentService
{
    public PaymentService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/Payment";
    }
    public async Task SubmitPaymentAsync(PaymentTabVM paymentTab)
    => await HandlePostResponse<PaymentTabVM>("SubmitPayment", paymentTab);
}
