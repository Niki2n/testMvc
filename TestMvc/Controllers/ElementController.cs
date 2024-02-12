using Microsoft.AspNetCore.Mvc;
using TestMvc.Models;

namespace TestMvc.Controllers
{
    public class ElementController : Controller
    {
        private static readonly string SuccessMessageView = "SuccessMassage";

        private ElementModel element = new() { Name = "Element 1", Data = DateTime.UtcNow, Url = "https://google.com", Id = 1 };

        public IActionResult Index(int id)
        {
            //To Do
            //Load from api
            return View(element);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            element.Data = DateTime.UtcNow;

            return View(element);
        }
        [HttpPost]
        public IActionResult Edit(ElementModel element)
        {
            element.Data = DateTime.UtcNow;

            return Index(element.Id);
        }

        public IActionResult Delete(int id, int catalogId)
        {
            element.Data = DateTime.UtcNow;

            return RedirectToAction("Details", "Catalog", new { id = id });
        }
    }
}
