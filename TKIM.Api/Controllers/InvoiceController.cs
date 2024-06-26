using iText.Layout.Element;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using TKIM.Api.Controllers.Base;
using TKIM.Api.Models.Invoice;
using TKIM.Api.Utils;

namespace TKIM.Api.Controllers;

public class InvoiceController : BaseController
{
    private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

    public InvoiceController(IMediator mediator, IRazorViewToStringRenderer razorViewToStringRenderer) : base(mediator)
    {
        _razorViewToStringRenderer = razorViewToStringRenderer;
    }

    [HttpPost("GenerateInvoice")]

    public async Task<IActionResult> GenerateInvoice(object value)
    {
        var obj = new InvoiceVM()
        {
            Invoice = new Entity.Entity.Invoice
            {
                Company = new Entity.Entity.Company
                {
                    NAME = "Test Company",
                    ADDRESS = "Test Address",
                },
                NAME = "Test Invoice",
                INVOICE_DATE = DateTime.Now,
                COMPANY_ID = Guid.NewGuid(),
                Customer = new Entity.Entity.Customer
                {
                    NAME = "Test Customer",
                    ADDRESS = "Test Address",
                },
                INVOICE_NUMBER = "123456",
            }
        };
        var htmlContent = await _razorViewToStringRenderer.RenderViewToStringAsync("Invoice/Index", obj);

        Document content = new Document();

        try
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a new Document object
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);

                // Create a PdfWriter instance binding the memory stream to the document
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                // Open the Document for writing
                pdfDoc.Open();

                // Fonts for the document
                Font companyFont = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK);
                Font addressFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
                Font descFont = FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.GRAY);
                Font invoiceFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.RED);
                Font tableHeaderFont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE);
                Font tableBodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);

                // Add company name, address, and description to the top left
                iTextSharp.text.Paragraph companyName = new("My Company Name", companyFont);
                companyName.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(companyName);

                iTextSharp.text.Paragraph companyAddress = new("1234 Main Street\nCity, State, ZIP Code", addressFont);
                companyAddress.Alignment = Element.ALIGN_LEFT;
                pdfDoc.Add(companyAddress);

                iTextSharp.text.Paragraph companyDescription = new("Leading provider of XYZ services", descFont);
                companyDescription.Alignment = Element.ALIGN_LEFT;
                companyDescription.SpacingAfter = 20;
                pdfDoc.Add(companyDescription);

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

                // Add more rows as needed
                // ...

                pdfDoc.Add(table);

                // Closing the Document
                pdfDoc.Close();

                // Convert the memory stream to a byte array
                byte[] pdfData = memoryStream.ToArray();

                // Return the PDF file as a FileContentResult
                return File(pdfData, "application/pdf", "Invoice.pdf");
            }
        }
        catch (Exception ex)
        {

            throw;
        }


        return Content("", "application/pdf"); // Return the HTML content
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
