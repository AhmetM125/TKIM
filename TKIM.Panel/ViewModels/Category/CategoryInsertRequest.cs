namespace TKIM.Panel.ViewModels.Category;

public record CategoryInsertRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }

    public string Barcode { get; set; }
    public byte[] Image { get; set; }
    public string Company { get; set; }
    public DateTime BestBeforeDate { get; set; } = new DateTime(1, 1, 1, 1, 1, 1);
}
