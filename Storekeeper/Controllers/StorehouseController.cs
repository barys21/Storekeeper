using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storekeeper.Models;
using Storekeeper.Services.Storehouses;
using System.Threading.Tasks;

namespace Storekeeper.Controllers
{
    public class StorehouseController : Controller
    {
        private readonly IStorehousesAppService _storehousesAppService;
        public StorehouseController(IStorehousesAppService storehousesAppService)
        {
            _storehousesAppService = storehousesAppService;
        }

        public IActionResult Index()
        {
            var storehouses = _storehousesAppService.GetAll();
            return View(storehouses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Storehouse storehouse)
        {
            if (!ModelState.IsValid)
                return View(storehouse);

            _storehousesAppService.Create(storehouse);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var storehouse = _storehousesAppService.GetById(id);
            if (storehouse == null)
                return NotFound();

            return View(storehouse);
        }

        [HttpPost]
        public IActionResult Edit(Storehouse storehouse)
        {
            if (!ModelState.IsValid)
                return View(storehouse);

            _storehousesAppService.Update(storehouse);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            _storehousesAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
