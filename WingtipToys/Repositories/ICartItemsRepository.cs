using System.Collections.Generic;
using System.Threading.Tasks;

namespace WingtipToys.Repositories
{
    public interface ICartItemsRepository
    {
        List<CartItem> GetCartItemsForId(string cartId);

        CartItem GetCartItem(string cartId, int productId);

        Task AddOrUpdateCart(string cartId, int productId);
    }
}