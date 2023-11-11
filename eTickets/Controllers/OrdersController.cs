﻿using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart) 
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var item = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = item;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var movieItem = await _moviesService.GetMovieByIdAsync(id);

            if (movieItem != null)  _shoppingCart.AddItemToCart(movieItem);

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var movieItem = await _moviesService.GetMovieByIdAsync(id);

            if (movieItem != null) _shoppingCart.RemoveItemFromCart(movieItem);

            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}