using web_api.Contracts;
using web_api.Model;

namespace web_api.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<ShoppingItem> _shoppingItems = new List<ShoppingItem>
        {
            new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 1", Price = 10, Manufacturer = "OK" }
        };


        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _shoppingItems;
        }

        public ShoppingItem GetById(Guid id)
        {
            return _shoppingItems.FirstOrDefault(item => item.Id == id);
        }

        public ShoppingItem Add(ShoppingItem item)
        {
            item.Id = Guid.NewGuid();
            _shoppingItems.Add(item);
            return item;
        }

        public void Remove(Guid id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _shoppingItems.Remove(item);
            }
        }
    }
}
