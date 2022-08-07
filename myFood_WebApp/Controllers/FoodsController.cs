using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myFood_WebApp.Data;
using myFood_WebApp.Data.Services;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IFoodsService _service;

        public FoodsController(IFoodsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allFoods = await _service.GetAllAsync(n => n.Resturant);
            return View(allFoods);
        }

        //Get: Foods/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var foodDetails = await _service.GetFoodByIdAsync(id);
            return View(foodDetails);

        }

        //Get: Foods/Create
        public async Task<IActionResult> Create()
        {

            var foodDropdownsData = await _service.GetNewFoodDropdownsValues();

            ViewBag.ResturantId = new SelectList(foodDropdownsData.Resutrants, "Id", "Name");

            return View();
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> Create(NewFoodVM food)
        {
            if (!ModelState.IsValid)
            {
                var foodDropdownsData = await _service.GetNewFoodDropdownsValues();
                ViewBag.ResturantId = new SelectList(foodDropdownsData.Resutrants, "Id", "Name");
                return View(food);
            }

            await _service.AddNewFoodAsync(food);
            return RedirectToAction(nameof(Index));

        }
    }
}
