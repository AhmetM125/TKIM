﻿using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.Receipt;

namespace TKIM.Panel.Services.Concrete;

public class PaymentItemService : BaseService, IPaymentItemService
{
    public PaymentItemService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/PaymentItems";
    }

    public async Task<List<InvoiceProducts>?> GetPaymentItemListByInvoiceId(Guid invoiceId)
        => await HandleReadResponse<List<InvoiceProducts>>($"GetPaymentItemListByInvoiceId?invoiceId={invoiceId}");
}
