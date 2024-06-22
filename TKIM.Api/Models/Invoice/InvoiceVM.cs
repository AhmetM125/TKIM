using TKIM.Entity.Entity;

namespace TKIM.Api.Models.Invoice;

public record InvoiceVM
{
    public Entity.Entity.Invoice Invoice { get; set; }
}
