using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.DA.Concrete;

public class PaymentService : IPaymentService
{
    private readonly TKIM_DbContext _context;

    public PaymentService(TKIM_DbContext context)
    {
        _context = context;
    }

    public async Task InsertPayment(Payment payment)
    {
        try
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
