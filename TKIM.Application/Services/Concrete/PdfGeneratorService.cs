
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using TKIM.Application.Services.Abstract;
using TKIM.Dto.InvoiceGenerate;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Api.Utils;

public class PdfGenerator : IPdfGeneratorService
{

    private readonly IInvoiceService _invoiceService;

    public PdfGenerator(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }


    public async Task<byte[]> GenerateInvoiceForSale(InvoiceGenerateDto invoiceGenerate)
    {
        try
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a new Document object
                Document pdfDoc = new(PageSize.A3, 25, 25, 30, 30);

                // Create a PdfWriter instance binding the memory stream to the document
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                // Open the Document for writing
                pdfDoc.Open();

                BaseFont font = BaseFont.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", "windows-1254", true); // to support Turkish characters
                Font fontNormal = new Font(font);

                // Fonts for the document
                Font companyFont = FontFactory.GetFont("Arial", 24, Font.BOLD, new BaseColor(78, 115, 223));
                Font addressFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
                Font phoneFont = FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.GRAY);

                Font invoiceFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.DARK_GRAY);
                Font tableBodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);

                // Add company name, address, and description to the top left
                Paragraph companyName = new("Yelim Ecza Ltd", companyFont);
                companyName.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(companyName);

                Paragraph companyAddress = new("Gültekin Şengör Sokak, Aküç Apt. Kumsal / Lefkoşa (Araç Kayıt Dairesi karşı yolu, Mamulcuoğlu karşısı, Keros Kuru Temizleme yanı)", addressFont);

                companyAddress.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(companyAddress);

                Paragraph companyMobilePhone = new("0 539 111 07 77", phoneFont);
                companyMobilePhone.Alignment = Element.ALIGN_LEFT;
                companyMobilePhone.SpacingAfter = 1;
                pdfDoc.Add(companyMobilePhone);

                Paragraph companyPhone = new("0 (392) 228 - 78 - 66", phoneFont);
                companyPhone.Alignment = Element.ALIGN_LEFT;
                companyPhone.SpacingAfter = 5;
                pdfDoc.Add(companyPhone);

                // Add invoice number to the top right
                PdfPTable invoiceTable = new PdfPTable(1);
                invoiceTable.DefaultCell.Border = Rectangle.NO_BORDER;
                invoiceTable.WidthPercentage = 100;
                invoiceTable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                var invoiceNumber = (await _invoiceService.InvoiceCount() + 1).ToString().PadLeft(6, '0');

                PdfPCell invoiceCell = new PdfPCell(new Phrase($"Fatura No #: {invoiceNumber}", invoiceFont));
                invoiceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                invoiceCell.Border = Rectangle.NO_BORDER;
                invoiceTable.AddCell(invoiceCell);

                pdfDoc.Add(invoiceTable);

                // Add a table to the middle with 5 columns
                PdfPTable table = new PdfPTable(4); // 4 columns: Name, Price, Quantity, Total
                table.WidthPercentage = 100;
                table.SpacingBefore = 30;

                // Define column widths
                float[] columnWidths = { 3f, 1.5f, 1f, 1.5f };
                table.SetWidths(columnWidths);

                // Adding table headers
                BuildTableHeader(table);


                //Foreach loop for adding products to the table
                BuildTableCells(table, invoiceGenerate.BasketItems, tableBodyFont);

                AddTableCellForBottom(table, "Ara Toplam", tableBodyFont, invoiceGenerate.TotalPrice - invoiceGenerate.TotalTax, true);
                AddTableCellForBottom(table, "Kdv", tableBodyFont, invoiceGenerate.TotalTax, false);
                AddTableCellForBottom(table, "Toplam Fiyat", tableBodyFont, invoiceGenerate.PaymentAmount, false);

                table.SpacingAfter = 30;

                pdfDoc.Add(table);

                Paragraph paragraph = new Paragraph();

                // Left aligned text
                Chunk leftText = new Chunk("Eksiksiz Teslim Eden");
                paragraph.Add(leftText);

                // Add a glue to push the right text to the end of the line
                Chunk glue = new Chunk(new VerticalPositionMark());
                paragraph.Add(glue);

                // Right aligned text
                Chunk rightText = new Chunk("Eksiksiz Teslim Alan");
                paragraph.Add(rightText);

                // Add the paragraph to the document
                pdfDoc.Add(paragraph);

                // Closing the Document
                pdfDoc.Close();

                // Convert the memory stream to a byte array
                byte[] pdfData = memoryStream.ToArray();

                return pdfData;
            }
        }
        catch (Exception)
        {
            return new byte[0];
        }


    }

    private void BuildTableHeader(PdfPTable table)
    {
        Font tableHeaderFont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE);

        AddTableHeader(table, "Isim", tableHeaderFont);
        AddTableHeader(table, "Fiyat", tableHeaderFont);
        AddTableHeader(table, "Miktar", tableHeaderFont);
        AddTableHeader(table, "Toplam", tableHeaderFont);
    }
    private void BuildTableCells(PdfPTable table, List<Product> products, Font font)
    {
        foreach (var item in products)
        {
            AddTableCell(table, item.Name, font);
            AddTableCell(table, $"{Math.Round((item.SalePrice), 2)} TRY", font);
            AddTableCell(table, item.QuantityInCart.ToString(), font);
            AddTableCell(table, $"{Math.Round(item.TotalPrice, 2)} TRY", font);
        }
    }
    private void AddOneEmptyTableRow(PdfPTable table, Font font)
    {
        for (int i = 0; i < 1; i++)
            for (int y = 0; y < 4; y++)
                AddTableCell(table, " ", font);
    }

    private void AddTableCellForBottom(PdfPTable table, string text, Font font, decimal value, bool hasGap)
    {
        if (hasGap)
            AddOneEmptyTableRow(table, font);

        for (int i = 0; i < 1; i++)
            for (int y = 0; y < 2; y++)
                AddTableCell(table, " ", font);


        PdfPCell cell = new PdfPCell(new Phrase(text, font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Padding = 5;
        table.AddCell(cell);

        AddTableCell(table, $"{Math.Round(value, 2)} TRY", font);
    }

    private void AddTableHeader(PdfPTable table, string text, Font font)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, font));
        cell.BackgroundColor = new BaseColor(78, 115, 223); // Light blue background
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Padding = 5;
        table.AddCell(cell);
    }
    private void AddTableCell(PdfPTable table, string text, Font font)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Padding = 5;
        table.AddCell(cell);
    }
}
