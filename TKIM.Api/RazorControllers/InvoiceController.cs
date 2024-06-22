using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TKIM.Api.Utils;

namespace TKIM.Api.RazorControllers;
[ApiController]
[Route("api/[controller]")]

public class InvoiceController : Controller
{




    [HttpGet("GenerateInvoice")]
    public async Task<IActionResult> GenerateInvoice()
    {
        object s = new { Name = "John Doe", Date = DateTime.Now, Amount = 1000 };
        return Content(null, "text/html"); // Return the HTML content
    }

}
