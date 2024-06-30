using Microsoft.EntityFrameworkCore;
using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Infastracture.Database.Context;

namespace TKIM.Infastracture.DA.Concrete;

public class PaymentItemService : IPaymentItemService
{
    private readonly TKIM_DbContext _context;

    public PaymentItemService(TKIM_DbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentItems>> GetPaymentItemListByInvoiceId(Guid invoiceId)
    {
        var paymentResponseId = await _context.Payments.Where(x => x.INVOICE_ID == invoiceId).Select(x => x.ID).FirstOrDefaultAsync();

        var paymentItemsResponse = await _context.PaymentItems.Where(x => x.PAYMENT_ID == paymentResponseId)
            .Select(x => new PaymentItems
            {
                ID = x.ID,
                SaleRecord = new SaleRecord
                {
                    PRODUCT_ID = x.SaleRecord.PRODUCT_ID,
                    QUANTITY_SOLD = x.SaleRecord.QUANTITY_CURRENT,
                    SALE_PRICE_EDITED = x.SaleRecord.SALE_PRICE_EDITED,
                    SALE_PRICE = x.SaleRecord.SALE_PRICE,
                    TOTAL = x.SaleRecord.TOTAL,
                    TOTAL_EDITED = x.SaleRecord.TOTAL_EDITED,
                    Product = new Product
                    {
                        NAME = x.SaleRecord.Product.NAME,
                    }
                }
            }).ToListAsync();
        return paymentItemsResponse;
    }
}
