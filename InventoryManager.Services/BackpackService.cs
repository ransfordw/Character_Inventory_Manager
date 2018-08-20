using InventoryManager.Data;
using InventoryManager.Models.Backpack;
using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class BackpackService
    {
        private readonly Guid _userId;

        public BackpackService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBackpackItem(BackpackItemCreate model)
        {
            var entity = new BackpackItem()
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
                ctx.BackpackItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<BackpackItemList> GetBackpackItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        ctx
                            .BackpackItems
                            .Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new BackpackItemList
                                    {
                                        BackpackID = e.BackpackID,
                                        CharacterID = e.CharacterID,
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

        public BackpackItemDetails GetBackpackItemById(int backpackId, int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .BackpackItems
                            .Single(e => e.BackpackID == backpackId && e.CharacterID == characterId && e.OwnerID == _userId);
                return
                        new BackpackItemDetails
                        {
                            BackpackID = entity.BackpackID,
                            CharacterID = entity.CharacterID,
                            ItemName = entity.ItemName,
                            ItemType = entity.ItemType,
                            ItemDescription = entity.ItemDescription,
                            ItemValue = entity.ItemValue,
                            Currency = entity.Currency,
                        };
                
            }
        }

        public bool UpdateBackpackItem(BackpackItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .BackpackItems
                            .Single(e => e.BackpackID == model.BackpackID && e.CharacterID == model.CharacterID && e.OwnerID == _userId);


                entity.ItemName = model.ItemName;
                entity.ItemType = model.ItemType;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemValue = model.ItemValue;
                entity.Currency = model.Currency;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBackpackItem(int backpackItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .BackpackItems
                            .Single(e => e.BackpackID == backpackItemId && e.OwnerID == _userId);
                ctx.BackpackItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
