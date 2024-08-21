using BoreholeData;
using BoreholeData.Entities;
using BoreholeData.Repositories;
using BoreholeMVCUI.Models;
using BoreholeMVCUI.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BoreholeMVCUI.Controllers
{
    public class BoreholeController : Controller
    {
        private BoreholeRepository repository;

        public BoreholeController(BoreholeContext context, ILogger<BoreholeRepository> log)
        {
            repository = new BoreholeRepository(context, log);
        }

        public IActionResult Index()
        {
            var allBoreholes = repository.GetAll().Select(bh => new BoreholeViewModel() { Id = bh.ID, X = bh.X, Y = bh.Y, Depth = bh.Depth, BoreholeType = (bh.GetType() == typeof(CableBorehole) ? BoreholeType.Cable : (bh.GetType() == typeof(DrillBorehole) ? BoreholeType.Drill : BoreholeType.Basic)) }).ToList();

            return View(allBoreholes);
        }

        public IActionResult Details(int id)
        {
            var borehole = repository.GetById(id);

            if (borehole.GetType() == typeof(CableBorehole))
                return View("CableView", new CableViewModel((CableBorehole)borehole));
            else if (borehole.GetType() == typeof(DrillBorehole))
                return View("DrillView", new DrillViewModel((DrillBorehole)borehole));

            return RedirectToAction("Index");
        }

        public IActionResult AddCable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCable(CableViewModel model)
        {
            if (ModelState.IsValid)
            {
                repository.Add(new CableBorehole() { Depth = model.Depth, X = model.X, Y = model.Y, CableStrength = model.CableStrength, CableType = model.CableType });

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult AddDrill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDrill(DrillViewModel model)
        {
            if (ModelState.IsValid)
            {
                repository.Add(new DrillBorehole() { Depth = model.Depth, X = model.X, Y = model.Y, DrillStrength = model.DrillStrength, DrillType = model.DrillType });

                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("borehole/delete/{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
