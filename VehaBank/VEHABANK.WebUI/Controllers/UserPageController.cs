using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using VEHABANK.Shared.Dto;

namespace VEHABANK.WebUI.Controllers
{
    public class UserPageController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserPageController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("VehaBankApi");
        }

        public async Task<IActionResult> Index()
        {
            int userId = 3055; // Örnek: Giriş yapmış kullanıcıdan alman gerek (Claims vs.)
            var response = await _httpClient.GetAsync($"api/Accounts/GetAccountsByUserId/{userId}");


            if (!response.IsSuccessStatusCode)
            {
                return View(new List<AccountDto>()); // Boş liste gönder
            }

            var json = await response.Content.ReadAsStringAsync();
            var accounts = JsonSerializer.Deserialize<List<AccountDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(accounts);
        }
    }
}
