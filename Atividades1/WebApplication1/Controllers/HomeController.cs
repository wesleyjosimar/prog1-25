using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult EncryptionDecryption()
        {
            var model = new EncryptionDecryption();
            return View(model);
        }

        [HttpPost]
        public IActionResult EncryptionDecryption(EncryptionDecryption model, string action)
        {
            if (!string.IsNullOrEmpty(model.userInput) || !string.IsNullOrEmpty(model.encryptedText))
            {
                if (action == "Encrypt" && !string.IsNullOrEmpty(model.userInput))
                {
                    model.encryptedText = model.Encrypt(model.userInput, model.shift);
                    model.decryptedText = null;
                    model.userInput = null;
                }
                else if (action == "Decrypt" && !string.IsNullOrEmpty(model.encryptedText))
                {
                    model.decryptedText = model.Decrypt(model.encryptedText, model.shift);
                    model.encryptedText = null; // Correct reset.
                }
                else
                {
                    ModelState.AddModelError("", "Please, enter text to Encrypt or Decrypt!");
                }
            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}