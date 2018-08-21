using InventoryManager.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Contracts
{
    public interface IItemService
    {
        
        bool CreateItem(ItemCreate model);
        IEnumerable<ItemListItem> GetItems();
        ItemDetails GetItemById(int itemId);
        bool UpdateItem(ItemEdit model);
        bool DeleteItem(int itemId);

    }
}
