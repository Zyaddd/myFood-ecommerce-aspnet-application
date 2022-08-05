using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace myFood_WebApp.Areas.Admin.Controllers
{
    [Area("Admins")]
    public class FoodsController : Controller
    {
        public IActionResult Index()
        {

            return View();

        }
/*
        public IActionResult Orders()
        {
            return View();
        }*/
    }

  
}
