namespace TKIM.Panel.ViewModels.Company;

public record CompanyModifyRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Number { get; set; }
    public string? Mail { get; set; }

}

