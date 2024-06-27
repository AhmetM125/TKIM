
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using TKIM.Application.Services.Abstract;

namespace TKIM.Api.Utils;

public class PdfGenerator : IPdfGeneratorService
{
    public void GeneratePdf()
    {
        throw new NotImplementedException();
    }

    public async Task GenerateInvoice(object value)
    {
        try
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a new Document object
                iTextSharp.text.Document pdfDoc = new(PageSize.A4, 25, 25, 30, 30);

                // Create a PdfWriter instance binding the memory stream to the document
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                // Open the Document for writing
                pdfDoc.Open();

                BaseFont font = BaseFont.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", "windows-1254", true); // to support Turkish characters
                Font fontNormal = new Font(font);

                // Fonts for the document
                Font companyFont = FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLUE);
                Font addressFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
                Font descFont = FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.GRAY);
                Font invoiceFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.RED);
                Font tableHeaderFont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE);
                Font tableBodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);

                // Add company name, address, and description to the top left
                iTextSharp.text.Paragraph companyName = new("Yelim Ecza Ltd", companyFont);
                companyName.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(companyName);


                iTextSharp.text.Paragraph companyAddress = new("Gültekin Şengör Sokak, Aküç Apt. Kumsal / Lefkoşa (Araç Kayıt Dairesi karşı yolu, Mamulcuoğlu karşısı, Keros Kuru Temizleme yanı)", addressFont);

                //
                //
                companyAddress.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(companyAddress);

                iTextSharp.text.Paragraph companyMobilePhone = new("0 539 111 07 77", descFont);
                companyMobilePhone.Alignment = Element.ALIGN_LEFT;
                companyMobilePhone.SpacingAfter = 20;
                pdfDoc.Add(companyMobilePhone);

                iTextSharp.text.Paragraph companyPhone = new("0(392) 228 - 78 - 66, descFont");
                companyPhone.Alignment = Element.ALIGN_LEFT;
                companyPhone.SpacingAfter = 20;
                pdfDoc.Add(companyPhone);



                // Add invoice number to the top right
                PdfPTable invoiceTable = new PdfPTable(1);
                invoiceTable.DefaultCell.Border = Rectangle.NO_BORDER;
                invoiceTable.WidthPercentage = 100;
                invoiceTable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                PdfPCell invoiceCell = new PdfPCell(new Phrase("Invoice #: 123456", invoiceFont));
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
                AddTableHeader(table, "Name", tableHeaderFont);
                AddTableHeader(table, "Price", tableHeaderFont);
                AddTableHeader(table, "Quantity", tableHeaderFont);
                AddTableHeader(table, "Total", tableHeaderFont);

                // Adding sample rows
                AddTableCell(table, "Product 1", tableBodyFont);
                AddTableCell(table, "$10.00", tableBodyFont);
                AddTableCell(table, "2", tableBodyFont);
                AddTableCell(table, "$20.00", tableBodyFont);

                AddTableCell(table, "Product 2", tableBodyFont);
                AddTableCell(table, "$15.00", tableBodyFont);
                AddTableCell(table, "1", tableBodyFont);
                AddTableCell(table, "$15.00", tableBodyFont);

                table.SpacingAfter = 30;
                // Add more rows as needed
                // ...

                pdfDoc.Add(table);


                var paragraph = new iTextSharp.text.Paragraph();

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

                // Return the PDF file as a FileContentResult
                return;
                //(pdfData, "application/pdf", "Invoice.pdf");
            }
        }
        catch (Exception ex)
        {
            return;
        }


    }

    private void AddTableHeader(PdfPTable table, string text, Font font)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, font));
        cell.BackgroundColor = new BaseColor(0, 119, 204); // Light blue background
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
