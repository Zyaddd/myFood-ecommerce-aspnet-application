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
        public OrdersController(IFoodsService foodsService, ShoppingCart shoppingCart)
        {
            _foodService = foodsService;
            _shoppingCart = shoppingCart;

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

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var item = await _foodService.GetFoodByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }
    }
}
