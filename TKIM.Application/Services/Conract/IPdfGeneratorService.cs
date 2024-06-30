using TKIM.Dto.InvoiceGenerate;

namespace TKIM.Application.Services.Abstract;

public interface IPdfGeneratorService
{
    Task<byte[]> GenerateInvoiceForSale(InvoiceGenerateDto invoiceGenerate); // Payment Class or invoice class will be to change
}
