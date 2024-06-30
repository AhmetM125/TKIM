using Microsoft.EntityFrameworkCore;
using TKIM.Entity.Entity;
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

    public async Task<List<Invoice>> GetInvoiceHistoryList()
    {
        return await _context.Invoices.AsNoTracking().Select(x => new Invoice
        {
            ID = x.ID,
            INVOICE_NUMBER = x.INVOICE_NUMBER,
            INVOICE_DATE = x.INVOICE_DATE,
            CUSTOMER_ID = x.CUSTOMER_ID,
            COMPANY_ID = x.COMPANY_ID,
            TOTAL = x.TOTAL,
            DESCRIPTION = x.DESCRIPTION,
        }).AsNoTracking().ToListAsync();
    }

    public async Task InsertInvoce(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task<int> InvoiceCount()
    {
        return await _context.Invoices.CountAsync();
    }
}
