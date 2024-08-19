using BoreholeData;
using BoreholeData.Repositories;
using BoreholeMVCUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoreholeMVCUI.Controllers
{
    public class BoreholeController : Controller
    {
        private BoreholeRepository repository;

        public BoreholeController(BoreholeContext context)
        {
            repository = new BoreholeRepository(context);
        }

        public IActionResult Index()
        {
            var allBoreholes = repository.GetAll().Select(bh => new BoreholeViewModel() { Id = bh.ID, X = bh.X, Y = bh.Y, Depth = bh.Depth }).ToList();

            return View(allBoreholes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BoreholeViewModel model)
        {
            if (ModelState.IsValid)
            {
                repository.Add(new BoreholeData.Entities.Borehole() { Depth = model.Depth, X = model.X, Y = model.Y });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
