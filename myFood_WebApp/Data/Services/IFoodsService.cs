using myFood_WebApp.Data.Base;
using myFood_WebApp.Data.ViewModel;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public interface IFoodsService: IEntityBaseRepository<Food>
    {

        Task<Food> GetFoodByIdAsync(int id);
        Task<NewFoodDropdownsVM> GetNewFoodDropdownsValues();
        Task AddNewFoodAsync(NewFoodVM data);
    }
}
