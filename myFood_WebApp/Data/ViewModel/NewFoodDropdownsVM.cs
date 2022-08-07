using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.ViewModel
{
    public class NewFoodDropdownsVM
    {
        public NewFoodDropdownsVM()
        {
            Resutrants = new List<Resturant>();
        }

        public List<Resturant> Resutrants{ get; set; }


    }
}
