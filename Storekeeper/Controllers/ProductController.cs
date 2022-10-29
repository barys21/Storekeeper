using Microsoft.AspNetCore.Mvc;
using Storekeeper.Models;
using Storekeeper.Services.ProductNomenclatures;
using Storekeeper.Services.Products;
using Storekeeper.Services.Storehouses;
using Storekeeper.ViewModels.Products;

namespace Storekeeper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsAppService _productsAppService;
        private readonly IProductNomenclaturesAppService _productNomenclaturesAppService;
        private readonly IStorehousesAppService _storehousesAppService;

        public ProductController(IProductsAppService productsAppService, IProductNomenclaturesAppService productNomenclaturesAppService,
            IStorehousesAppService storehousesAppService)
        {
            _productsAppService = productsAppService;
            _productNomenclaturesAppService = productNomenclaturesAppService;
            _storehousesAppService = storehousesAppService;
        }

        public IActionResult Index()
        {
            var products = _productsAppService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            var vm = new CreateProductViewModel
            {
                ProductNomenclatureList = _productNomenclaturesAppService.GetAll(),
                StorehousesList = _storehousesAppService.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var product = new Product
            {
                ProductNomenclatureId = input.ProductNomenclatureId,
                StorehouseId = input.StorehouseId,
                Quantity = input.Quantity,
                Price = input.Price,
                Sum = input.Sum
            };

            _productsAppService.Create(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var product = _productsAppService.GetById(id);
            if (product == null)
                return NotFound();

            var vm = new EditProductViewModel
            {
                Id = product.Id,
                ProductNomenclatureId = product.ProductNomenclatureId,
                StorehouseId = product.StorehouseId,
                Quantity = product.Quantity,
                Price = product.Price,
                Sum = product.Sum,
                ProductNomenclatureList = _productNomenclaturesAppService.GetAll(),
                StorehousesList = _storehousesAppService.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var product = new Product
            {
                Id = input.Id,
                ProductNomenclatureId = input.ProductNomenclatureId,
                StorehouseId = input.StorehouseId,
                Quantity = input.Quantity,
                Price = input.Price,
                Sum = input.Sum
            };

            _productsAppService.Update(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            _productsAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
