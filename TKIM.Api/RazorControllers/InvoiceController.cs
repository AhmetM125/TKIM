using Microsoft.AspNetCore.Mvc;

namespace TKIM.Api.RazorControllers;

public class InvoiceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
