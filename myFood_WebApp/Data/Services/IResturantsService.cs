using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public interface IResturantsService
    {
        Task<IEnumerable<Resturant>> GetAllAsync();
        Task<Resturant> GetByIdAsync(int id);
        Task AddAsync(Resturant resturant);
        Task<Resturant> updateAsync(int id, Resturant newResturant);
        Task DeleteAsync(int id);

    }
}
