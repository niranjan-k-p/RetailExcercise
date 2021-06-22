using System.Collections.Generic;

namespace WingtipToys.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public List<Product> Products { get; set; }

        public CartItem NewCartItem { get; set; }
    }
}