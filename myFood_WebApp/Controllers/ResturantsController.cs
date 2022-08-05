using Microsoft.AspNetCore.Mvc;
using myFood_WebApp.Data;
using myFood_WebApp.Data.Services;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Controllers
{
    public class ResturantsController : Controller
    {
        private readonly IResturantsService _service;

        public ResturantsController(IResturantsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allResturants = await _service.GetAllAsync();
            return View(allResturants);
        }

        //Get: Resturants/Create
        public IActionResult Create()
        {
            return View();
        }

        //post: Resturants/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoPicture, Name, Address")]Resturant resturant)
        {
            if (!ModelState.IsValid)
            {
                return View(resturant);
            }
            await _service.AddAsync(resturant);
            return RedirectToAction(nameof(Index));
        }

        //Get: Resturants/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var resturantDetails = await _service.GetByIdAsync(id);

            if (resturantDetails == null)
                return View("NotFound");

            return View(resturantDetails);

        }

        //Get: Resturants/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var resturantDetails = await _service.GetByIdAsync(id);
            if (resturantDetails == null) return View("NotFound");
            return View(resturantDetails);
        }

        //post: Resturants/Create (update)
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, LogoPicture, Name, Address")] Resturant resturant)
        {
            if (!ModelState.IsValid)
            {
                return View(resturant);
            }
            await _service.updateAsync(id, resturant);
            return RedirectToAction(nameof(Index));
        }

        //Get: Resturants/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var resturantDetails = await _service.GetByIdAsync(id);
            if (resturantDetails == null) return View("NotFound");
            return View(resturantDetails);
        }

        //post: Resturants/Create (update)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resturantDetails = await _service.GetByIdAsync(id);
            if (resturantDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
