using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.DA.Concrete;

public class InvoiceService : IInvoiceService
{
    private readonly TKIM_DbContext _context;

    public InvoiceService(TKIM_DbContext context)
    {
        _context = context;
    }


}
