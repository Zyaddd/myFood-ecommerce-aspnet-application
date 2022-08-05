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

        public IActionResult Index()
        {
            var allResturants =  _service.GetAll();
            return View(allResturants);
        }

        //Get: Resturants/Create
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoPicture, Name, Address")]Resturant resturant)
        {
            if (!ModelState.IsValid)
            {
                return View(resturant);
            }
            _service.Add(resturant);
            return RedirectToAction(nameof(Index));


        }
    }
}
