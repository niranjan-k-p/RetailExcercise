using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WingtipToys.Repositories;
using WingtipToys.ViewModels;

namespace WingtipToys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICartItemsRepository _cartItemsRepository;
        private readonly string _cartId = System.Configuration.ConfigurationManager.AppSettings["CartId"];

        public ProductsController(IProductsRepository productsRepository, ICartItemsRepository cartItemsRepository)
        {
            _productsRepository = productsRepository;
            _cartItemsRepository = cartItemsRepository;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var cars = _productsRepository.GetProductByCategory(1);

            return View(await cars);
        }

        public async Task<ActionResult> AddToCart(int productId)
        {
            await _cartItemsRepository.AddOrUpdateCart(_cartId, productId);

            var cartItems = _cartItemsRepository.GetCartItemsForId(_cartId);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                Products = cartItems.Select(c => c.Product).ToList(),
                NewCartItem = _cartItemsRepository.GetCartItem(_cartId, productId)
            };

            ViewBag.Func = "ClearMessage()";
            return PartialView("CartItemsMessageArea", viewModel);
        }
    }
}
