using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Storekeeper.Dtos.Products;
using Storekeeper.Models;
using Storekeeper.Services.ProductNomenclatures;
using Storekeeper.Services.Products;
using Storekeeper.Services.Storehouses;
using Storekeeper.Services.TypeOperations;
using Storekeeper.ViewModels.Products;
using System.Linq;

namespace Storekeeper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsAppService _productsAppService;
        private readonly IProductNomenclaturesAppService _productNomenclaturesAppService;
        private readonly IStorehousesAppService _storehousesAppService;
        private readonly IMapper _mapper;
        private readonly ITypeOperationsAppService _typeOperationsAppService;

        public ProductController(IProductsAppService productsAppService, IProductNomenclaturesAppService productNomenclaturesAppService,
            IStorehousesAppService storehousesAppService, IMapper mapper, ITypeOperationsAppService typeOperationsAppService)
        {
            _productsAppService = productsAppService;
            _productNomenclaturesAppService = productNomenclaturesAppService;
            _storehousesAppService = storehousesAppService;
            _mapper = mapper;
            _typeOperationsAppService = typeOperationsAppService;
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
            product.TypeOperationId = _typeOperationsAppService.GetAll().Where(e => e.Name == "Приход").First().Id;
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

            var vm = _mapper.Map<EditProductViewModel>(product.Product);
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

        // Списание
        public IActionResult WriteOff(int id)
        {
            if (id == 0)
                return NotFound();

            var product = _productsAppService.GetById(id);
            if (product == null)
                return NotFound();

            product.Product.ParentProductId = id;
            var vm = _mapper.Map<WriteOffViewModel>(product.Product);
            vm.ProductName = product.ProductNomenclatureName;
            vm.Balance = product.Product.Quantity;
            vm.Quantity = 0;
            vm.StorehousesList = _storehousesAppService.GetAll();

            return View(vm);
        }

        [HttpPost]
        public IActionResult WriteOff(WriteOffViewModel input)
        {
            if (!ModelState.IsValid)
                return View(input);

            if (input.Quantity == 0)
                return View(input);

            if (input.Balance < input.Quantity)
                return View();

            var writeOff = _mapper.Map<WriteOffInput>(input);
            writeOff.TypeId = _typeOperationsAppService.GetAll().Where(e => e.Name == "Списание").First().Id;
            _productsAppService.WriteOff(writeOff);

            return RedirectToAction(nameof(Index));
        }
    }
}
