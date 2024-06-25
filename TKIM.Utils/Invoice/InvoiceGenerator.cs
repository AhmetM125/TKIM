namespace TKIM.Utils.Invoice;

public static class InvoiceGenerator
{
    public static string GenerateInvoice()
    {
        return DateTime.Now.ToString("dd,MM,yyyy,HH,MM").Replace(",", "");
    }

}
