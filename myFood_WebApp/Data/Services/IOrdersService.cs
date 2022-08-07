using myFood_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Data.Services
{
    public interface IOrdersService
    {

        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

    }
}
