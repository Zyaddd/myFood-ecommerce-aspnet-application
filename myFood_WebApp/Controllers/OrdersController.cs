using Microsoft.AspNetCore.Mvc;
using myFood_WebApp.Data.Cart;
using myFood_WebApp.Data.Services;
using myFood_WebApp.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IFoodsService _foodService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IFoodsService foodsService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _foodService = foodsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }
        
        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);

        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _foodService.GetFoodByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _foodService.GetFoodByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
