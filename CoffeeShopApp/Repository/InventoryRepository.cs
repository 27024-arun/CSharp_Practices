using System.Collections.Concurrent;
using CoffeeShopApp.Enums;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Repository
{
    internal class InventoryRepository
    {
        private readonly ConcurrentBag<InventoryItems> _inventoryItems = new ConcurrentBag<InventoryItems>();

        public InventoryRepository()
        {
            _inventoryItems.Add(new InventoryItems(1, "Milk", 1000, 1000));
            _inventoryItems.Add(new InventoryItems(2, "Coffee Bean", 1000, 1000));
            _inventoryItems.Add(new InventoryItems(3, "Sugar", 1000, 1000));
            _inventoryItems.Add(new InventoryItems(4, "Water", 1000, 1000));
        }

        public void RefillStock()
        {
            foreach (var item in _inventoryItems)
            {
                item.CurrentQuantity = item.MaxQuantity;
            }
        }

        public IEnumerable<InventoryItems> GetAll()
        {
            return this._inventoryItems;
        }

        public void ReduceStock(IngredientRequired ingredientRequired)
        {
            InventoryItems inventoryItems = this._inventoryItems.First(item => item.Id == ingredientRequired.Id);
            inventoryItems.CurrentQuantity -= ingredientRequired.Quantity;
        }
    }
}
