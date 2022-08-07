using Microsoft.EntityFrameworkCore;
using myFood_WebApp.Data.Base;
using myFood_WebApp.Data.ViewModel;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public class FoodsService: EntityBaseRepository<Food>, IFoodsService
    {
        private readonly AppDbContext _context;
        public FoodsService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewFoodAsync(NewFoodVM data)
        {
            var newFood = new Food()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                FoodPictureURL = data.FoodPictureURL,
                FoodCategory = data.FoodCategory,
                ResturantID = data.ResturantID
            };

            await _context.Foods.AddAsync(newFood);
            await _context.SaveChangesAsync();

          
        }

        public async Task<Food> GetFoodByIdAsync(int id)
        {
            var FoodDetails = await _context.Foods
                .Include(r => r.Resturant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return FoodDetails;
        }

        public async Task<NewFoodDropdownsVM> GetNewFoodDropdownsValues()
        {
            var response = new NewFoodDropdownsVM();

            response.Resutrants = await _context.Resturants.OrderBy(n => n.Name).ToListAsync();

            return response;
        }
    }
}
