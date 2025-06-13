using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using VEHABANK.WebUI.Models;

namespace VEHABANK.WebUI.Controllers
{
    public class AuthJwtController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthJwtController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:7060/api/AuthenticationJwt/Login", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);
                var token = doc.RootElement.GetProperty("token").GetString();
                var userId = doc.RootElement.GetProperty("userId").GetInt32();

                HttpContext.Session.SetString("jwtToken", token);
                HttpContext.Session.SetInt32("userId", userId);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Giriş başarısız.");
            return View(model);
        }

    }

}
