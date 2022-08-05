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
        public async Task AddAsync(Resturant resturant)
        {
             await _context.Resturants.AddAsync(resturant);
             await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var result = await _context.Resturants.FirstOrDefaultAsync(n => n.Id == id);
            _context.Resturants.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Resturant>> GetAllAsync()
        {
            var result = await _context.Resturants.ToListAsync();
            return result;
        }


        public async Task<Resturant> GetByIdAsync(int id)
        {
            var result = await _context.Resturants.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Resturant> updateAsync(int id, Resturant newResturant)
        {
            _context.Update(newResturant);
            await _context.SaveChangesAsync();
            return newResturant;
        }
    }
}
