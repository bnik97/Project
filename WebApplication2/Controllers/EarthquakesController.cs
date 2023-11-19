
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.Models;
using System.Linq;
using global::WebApplication2.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    public class EarthquakesController : Controller
    {
        private readonly EarthquakeService _earthquakeService;

        public EarthquakesController(EarthquakeService earthquakeService)
        {
            _earthquakeService = earthquakeService;
        }

        [HttpGet]
        public IActionResult Index(string? coordinates)
        {
            IEnumerable<Earthquake> earthquakes;

            if (coordinates != null)
            {
                earthquakes = _earthquakeService.SearchByCoordinates(coordinates);
            }
            else
            {
                earthquakes = _earthquakeService.GetAll();
            }

            return View(earthquakes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Действие для обработки данных формы
        [HttpPost]
        public IActionResult Create(Earthquake earthquake)
        {
            if (ModelState.IsValid)
            {
                _earthquakeService.Add(earthquake);
                return RedirectToAction("Index");
            }

            return View(earthquake);
        }
    }
}
