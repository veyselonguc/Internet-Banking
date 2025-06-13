using Microsoft.AspNetCore.Mvc;

namespace VEHABANK.WebUI.Controllers
{
    public class CounterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UnblockCard()
        {
            return View();
        }

        public IActionResult AccountApproval()
        {
            return View();
        }

        public IActionResult FeeIntervention()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UnblockCard(string CardNumber)
        {
            TempData["SuccessMessage"] = "Kart blokesi başarıyla kaldırıldı!";
            return RedirectToAction("UnblockCard");
        }

        [HttpPost]
        public IActionResult AccountApproval(string AccountNumber)
        {
            TempData["SuccessMessage"] = "Hesap başarıyla onaylandı/aktifleştirildi!";
            return RedirectToAction("AccountApproval");
        }

        [HttpPost]
        public IActionResult FeeIntervention(string TransactionNumber, string NewFee)
        {
            TempData["SuccessMessage"] = "İşlem ücreti başarıyla güncellendi!";
            return RedirectToAction("FeeIntervention");
        }
    }
} 