using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myFood_WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Controllers
{
    public class FoodsController : Controller
    {
        private readonly AppDbContext _context;

        public FoodsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allFoods = await _context.Foods.Include(n => n.Resturant).ToListAsync();
            return View(allFoods);
        }
    }
}
