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

        public bool CreateBackpack(BackpackCreate model)
        {
            var entity = new Backpack()
            {
                OwnerID = _userId,
                CharacterID = model.CharacterID,
                ItemID = model.ItemID,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Backpacks.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<BackpackList> GetBackpacks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        ctx
                            .Backpacks
                            .Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new BackpackList
                                    {
                                        BackpackID = e.BackpackID,
                                        CharacterID = e.CharacterID,
                                        ItemID = e.ItemID
                                    }
                            );
                return query.ToArray();
            }
        }

        public BackpackDetails GetBackpackById(int backpackId, int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Backpacks
                            .Single(e => e.BackpackID == backpackId && e.CharacterID == characterId && e.OwnerID == _userId);
                return
                        new BackpackDetails
                        {
                            BackpackID = entity.BackpackID,
                            CharacterID = entity.CharacterID,
                            ItemID = entity.ItemID,
                        };
                
            }
        }



        //public IEnumerable<BackpackList> GetBackpackByCharacterId ()
        //{
            
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //                ctx
        //                    .Backpacks
        //                    .Where(e => e.OwnerID == _userId /*&& e.CharacterID == characterId*/)
        //                    .Select(
        //                        e =>
        //                            new BackpackList
        //                            {
        //                                BackpackID = e.BackpackID,
        //                                CharacterID = e.CharacterID,
        //                                ItemID = e.ItemID,
        //                            }
        //                    );
        //        return query.ToArray();
        //    }
        //}

        //public bool UpdateBackpack(BackpackEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //               ctx
        //                    .Backpacks
        //                    .Single(e => e.BackpackID == model.BackpackID && e.CharacterID == model.CharacterID && e.OwnerID == _userId);


        //        entity.ItemName = model.ItemName;
        //        entity.ItemType = model.ItemType;
        //        entity.ItemDescription = model.ItemDescription;
        //        entity.ItemValue = model.ItemValue;
        //        entity.Currency = model.Currency;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        public bool DeleteBackpack(int backpackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Backpacks
                            .Single(e => e.BackpackID == backpackId && e.OwnerID == _userId);
                ctx.Backpacks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
