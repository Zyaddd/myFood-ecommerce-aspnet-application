using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public interface IResturantsService
    {
        IEnumerable<Resturant> GetAll();
        Resturant GetById(int id);
        Task Add(Resturant resturant);
        Resturant update(int id, Resturant newResturant);
        void Delete(int id);

    }
}
