using InventoryManager.Contracts;
using InventoryManager.Data;
using InventoryManager.Models.ItemModels;
using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class ItemService : IItemService
    {
        private readonly Guid _userId;
        private readonly int _characterId;

        public ItemService(Guid userId)
        {
            _userId = userId;
        }

        public ItemService(Guid userId, int id)
        {
            _userId = userId;
            _characterId = id;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity = new Item()
            {
                OwnerID = _userId,
                ItemName = model.ItemName,
                ItemType = model.ItemType,
                ItemDescription = model.ItemDescription,
                ItemValue = model.ItemValue,
                Currency = model.Currency,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Items
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                             e =>
                                new ItemListItem
                                {
                                    ItemID = e.ItemID,
                                    ItemName = e.ItemName,
                                    ItemType = e.ItemType,
                                    ItemDescription = e.ItemDescription,
                                    ItemValue = e.ItemValue,
                                    Currency = e.Currency,
                                }
                     );
                return query.ToArray();
            }
        }

        public ItemDetails GetItemById(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                      ctx
                         .Items
                         .Single(e => e.ItemID == itemId && e.OwnerID == _userId);
                return
                    new ItemDetails
                    {
                        ItemID = entity.ItemID,
                        ItemName = entity.ItemName,
                        ItemType = entity.ItemType,
                        ItemDescription = entity.ItemDescription,
                        ItemValue = entity.ItemValue,
                        Currency = entity.Currency,
                    };
            }
        }

        public bool UpdateItem(ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Items
                            .Single(e => e.ItemID == model.ItemID && e.OwnerID == _userId);

                
                entity.ItemName = model.ItemName;
                entity.ItemType = model.ItemType;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemValue = model.ItemValue;
                entity.Currency = model.Currency;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Items
                            .Single(e => e.ItemID == itemId && e.OwnerID == _userId);
                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
