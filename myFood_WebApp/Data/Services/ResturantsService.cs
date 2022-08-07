using Microsoft.EntityFrameworkCore;
using myFood_WebApp.Data.Base;
using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public class ResturantsService : EntityBaseRepository<Resturant>, IResturantsService
    {
        
        private readonly AppDbContext _context;

        public ResturantsService(AppDbContext context): base(context)
        {
        }
        
    }
}
