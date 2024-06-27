namespace TKIM.Application.Services.Abstract;

public interface IPdfGeneratorService
{
    byte[] GenerateInvoice(object value); // Payment Class or invoice class will be to change
}
