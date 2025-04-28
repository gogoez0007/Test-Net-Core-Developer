using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(HttpClient httpClient, ILogger<HomeController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"] as string;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRegistration(RegistrationModel model)
        {
            string message = null; 

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError($"Model State Error: {error.ErrorMessage}");
                }

                message = "⚠️ There are errors in the form.";
            }
            else
            {
                var content = new MultipartFormDataContent();

                content.Add(new StringContent(model.CompanyName), "CompanyName");
                content.Add(new StringContent(model.NPWP), "NPWP");
                content.Add(new StringContent(model.DirectorName), "DirectorName");
                content.Add(new StringContent(model.PICName), "PICName");
                content.Add(new StringContent(model.Email), "Email");
                content.Add(new StringContent(model.PhoneNumber), "PhoneNumber");
                content.Add(new StringContent(model.AllowAccessAfterClosing.ToString()), "AllowAccessAfterClosing");

                if (model.NPWPFile != null)
                {
                    var fileContent = new StreamContent(model.NPWPFile.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.NPWPFile.ContentType);
                    content.Add(fileContent, "NPWPFilePath", model.NPWPFile.FileName); 
                }

                if (model.PowerOfAttorneyFile != null)
                {
                    var fileContent = new StreamContent(model.PowerOfAttorneyFile.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.PowerOfAttorneyFile.ContentType);
                    content.Add(fileContent, "PowerOfAttorneyFilePath", model.PowerOfAttorneyFile.FileName);
                }

                // Kirim data ke API
                try
                {
                    var response = await _httpClient.PostAsync("http://localhost:5288/api/createregisterdata/create", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        message = "✅ Data successfully submitted!";
                        _logger.LogInformation("Data successfully submitted to API.");
                    }
                    else
                    {
                        message = $"❌ Failed to submit! Server says: {responseBody}";
                        _logger.LogError($"API Error: {response.StatusCode} - {responseBody}");
                    }
                }
                catch (Exception ex)
                {
                    message = $"❌ Connection Error: {ex.Message}";
                    _logger.LogError($"Connection Error: {ex}");
                }
            }

            TempData["Message"] = message;

            return RedirectToAction("Index");
        }
    }
}
