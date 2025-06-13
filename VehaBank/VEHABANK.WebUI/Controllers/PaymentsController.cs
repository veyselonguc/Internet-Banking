using Microsoft.AspNetCore.Mvc;

namespace VEHABANK.WebUI.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Invoice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Invoice(string InvoiceNumber, string Amount, string Type)
        {
            // Burada ödeme işlemi yapılabilir (dummy)
            TempData["SuccessMessage"] = "Ödeme başarılı!";
            return RedirectToAction("Invoice");
        }
        public IActionResult Dormitory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dormitory(string IdentityNumber, string Amount)
        {
            // Burada ödeme işlemi yapılabilir (dummy)
            TempData["SuccessMessage"] = "Yurt ödemesi başarılı!";
            return RedirectToAction("Dormitory");
        }
    }
} 