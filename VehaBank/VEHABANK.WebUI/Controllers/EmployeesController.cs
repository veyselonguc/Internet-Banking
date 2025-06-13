using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using VEHABANK.Shared.Dto;

namespace VEHABANK.WebUI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ManageEmployees()
        {
            var client = _httpClientFactory.CreateClient("VehaBankApi");

            var response = await client.GetFromJsonAsync<List<EmployeeDto>>("api/Employees");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto dto)
        {
            var client = _httpClientFactory.CreateClient("VehaBankApi");
            var response = await client.PostAsJsonAsync("api/Employees", dto);

            if (response.IsSuccessStatusCode)
                TempData["SuccessMessage"] = "Ekleme başarılı.";

            return View("ManageEmployees");
        }
        public IActionResult AddEmployee()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient("VehaBankApi");
            var response = await client.DeleteAsync($"api/Employees/Delete/{id}");

            if (response.IsSuccessStatusCode)
                TempData["SuccessMessage"] = "Personel başarıyla silindi.";
            else
                TempData["SuccessMessage"] = "Silme işlemi başarısız.";

            return RedirectToAction("ManageEmployees");
        }


        // GET: Düzenleme sayfasını getir
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient("VehaBankApi");
            var response = await client.GetAsync("api/Employees");
            if (!response.IsSuccessStatusCode) return NotFound();

            var list = await response.Content.ReadFromJsonAsync<List<EmployeeDto>>();
            var employee = list.FirstOrDefault(x => x.Id == id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: Düzenlenen veriyi API'ye gönder
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateDto dto)
        {
            var client = _httpClientFactory.CreateClient("VehaBankApi");
            var response = await client.PostAsJsonAsync("api/Employees/Update", dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Personel güncellendi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Güncelleme başarısız.";
            }

            return RedirectToAction("ManageEmployees");
        }


    }

}