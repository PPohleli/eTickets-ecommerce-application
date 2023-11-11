using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Data.ViewComponents
{
    public class ShoppingCartSummery : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummery(ShoppingCart shoppingCart) 
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var cartItems = _shoppingCart.GetShoppingCartItems();

            return View(cartItems.Count);
        }
    }
}
