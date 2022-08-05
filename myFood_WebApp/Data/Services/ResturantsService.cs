using Microsoft.EntityFrameworkCore;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public class ResturantsService : IResturantsService
    {
        
        private readonly AppDbContext _context;

        public ResturantsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Resturant resturant)
        {
             _context.Resturants.Add(resturant);
             _context.SaveChanges();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resturant> GetAll()
        {
            var result = _context.Resturants.ToList();
            return result;
        }


        public Resturant GetById(int id)
        {
            var result = _context.Resturants.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public Resturant update(int id, Resturant newResturant)
        {
            throw new NotImplementedException();
        }
    }
}
