using Elfie.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestMvc.Interfaces;
using TestMvc.Models;
using TestMvc.ModelView.Catalog;

namespace TestMvc.Controllers
{
    public class CatalogController : Controller
    {
        private static readonly string SuccessMessageView = "SuccessMassage";
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        List<CatalogModel> catalogs = []; // GET: CatalogController

        public async Task<ActionResult> Index(string search)
        {
            var resp = await (!String.IsNullOrEmpty(search) ?
                _catalogService.FindByAsync(search)
                :
                _catalogService.GetAllAsync());

            if (resp.Success && resp.Response!.Count != 0)
            { 
                return View(resp.Response);
            }

            return View(catalogs);
        }

        // GET: CatalogController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var resp = await _catalogService.GetByAsync(id);
            if (resp.Success)
                return View("Details/Index", resp.Response);

            return View(catalogs.FirstOrDefault());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var catalog =  await _catalogService.GetByAsync(id);
            return catalog.Success ?
                View(new UpdateCatalogViewModel(catalog.Response!)) 
                : View("NotFound", $"Entity with id:{id} not found");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CatalogModel catalog)
        {
            var resp = await _catalogService.EditAsync(catalog);

            return resp.Success ? 
                RedirectToAction("Index")
                : View("Error", resp.Error);
        }
        // POST: CatalogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CatalogModel newCatalog)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage("CreateError");

                await _catalogService.CreateAsync(newCatalog);

                return View(SuccessMessageView, "Resource created successfully!");
            }
            catch
            {
                return View("Index");
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _catalogService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
