﻿using CinemaTickets.Data.Cart;
using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels;
using CinemaTickets.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShoppingCart = CinemaTickets.Data.Cart.ShoppingCart;

namespace CinemaTickets.Controllers { 

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly ShoppingCart _shoppingCart;
    private readonly IOrdersService _ordersService;
    public OrdersController(IMoviesService movieService, ShoppingCart shoppingCart, IOrdersService ordersService)
    {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
    }

    public async Task<IActionResult> Index()
    {
        string userId = "";
        var orders = await _ordersService.GetOrderByUserIdAsync(userId);
        return View(orders);
    }
    public IActionResult ShoppingCart()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;
        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(response);
    }

    public async Task<IActionResult> AddItemToShoppingCart(int id)
    {
        var item = await _movieService.GetMovieByIdAsync(id);
        if (item != null)
        {
            _shoppingCart.AddItemToCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
    {
        var item = await _movieService.GetMovieByIdAsync(id);
        if (item != null)
        {
            _shoppingCart.RemoveItemFromCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> SendOrder()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        string userId = "";
        string userEmailAdress = "";

        await _ordersService.StoredOrderAsync(items, userId, userEmailAdress);
        await _shoppingCart.ClearShoppingCartAsync();
        return View("OrderCompleted");

    }
}
}
   
