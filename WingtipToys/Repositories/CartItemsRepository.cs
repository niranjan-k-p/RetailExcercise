using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingtipToys.Repositories
{
    internal class CartItemsRepository : ICartItemsRepository
    {
        private readonly ICentralRepository _centralRepository;

        public CartItemsRepository(ICentralRepository centralRepository)
        {
            _centralRepository = centralRepository;
        }

        public List<CartItem> GetCartItemsForId(string cartId)
        {
            return _centralRepository.EntitiesDb.CartItems.Where(c => c.CartId == cartId).ToList();
        }

        public CartItem GetCartItem(string cartId, int productId)
        {
            return _centralRepository.EntitiesDb.CartItems.FirstOrDefault(c => c.CartId == cartId && c.ProductId == productId);
        }

        public async Task AddOrUpdateCart(string cartId, int productId)
        {
            try
            {
                var product = _centralRepository.EntitiesDb.Products.FirstOrDefault(p => p.ProductID == productId);

                if (product == null)
                {
                    //TODO: log error
                    return;
                }

                var cartItem = GetCartItem(cartId, productId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    _centralRepository.EntitiesDb.CartItems.Add(new CartItem
                    {
                        CartId = cartId,
                        ProductId = productId,
                        Product = product,
                        DateCreated = DateTime.Now,
                        Quantity = 1,
                        ItemId = Guid.NewGuid().ToString()
                    });
                }

                // TODO: Log if save changes is successful based on number returned
                await _centralRepository.Save();
            }
            catch (Exception e)
            {
                // TODO: log exception as error, instead of console write
                Console.WriteLine(e);
            }
        }
    }
}