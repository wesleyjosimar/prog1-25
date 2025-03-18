using Microsoft.AspNetCore.Mvc;
using numtowords.Models;

namespace numtowords.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new NumberModel());
        }

        [HttpPost]
        public IActionResult ConvertNumber(NumberModel model)
        {
            if (ModelState.IsValid)
            {
                model.NumberInWords = NumberConverter.NumberToWords(model.Number);
                model.Category = NumberConverter.GetCategory(model.Number);
            }
            return View("Index", model);
        }
    }
}
