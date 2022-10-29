using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductController(IProductsAppService productsAppService, IProductNomenclaturesAppService productNomenclaturesAppService,
            IStorehousesAppService storehousesAppService, IMapper mapper)
        {
            _productsAppService = productsAppService;
            _productNomenclaturesAppService = productNomenclaturesAppService;
            _storehousesAppService = storehousesAppService;
            _mapper = mapper;
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

            var product = _mapper.Map<Product>(input);
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

            var vm = _mapper.Map<EditProductViewModel>(product);
            vm.ProductNomenclatureList = _productNomenclaturesAppService.GetAll();
            vm.StorehousesList = _storehousesAppService.GetAll();
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var product = _mapper.Map<Product>(input);
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
