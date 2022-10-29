using Microsoft.AspNetCore.Mvc;
using Storekeeper.Models;
using Storekeeper.Services.ProductNomenclatures;

namespace Storekeeper.Controllers
{
    public class ProductNomenclatureController : Controller
    {
        private readonly IProductNomenclaturesAppService _productNomenclaturesAppService;
        public ProductNomenclatureController(IProductNomenclaturesAppService productNomenclaturesAppService)
        {
            _productNomenclaturesAppService = productNomenclaturesAppService;
        }

        public IActionResult Index()
        {
            var productNomenclature = _productNomenclaturesAppService.GetAll();
            return View(productNomenclature);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductNomenclature productNomenclature)
        {
            if (!ModelState.IsValid)
                return View(productNomenclature);

            _productNomenclaturesAppService.Create(productNomenclature);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var productNomenclature = _productNomenclaturesAppService.GetById(id);
            if (productNomenclature == null)
                return NotFound();

            return View(productNomenclature);
        }

        [HttpPost]
        public IActionResult Edit(ProductNomenclature productNomenclature)
        {
            if (!ModelState.IsValid)
                return View(productNomenclature);

            _productNomenclaturesAppService.Update(productNomenclature);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            _productNomenclaturesAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
