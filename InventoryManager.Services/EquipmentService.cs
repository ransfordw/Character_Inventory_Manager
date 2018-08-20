using InventoryManager.Contracts;
using InventoryManager.Data;
using InventoryManager.Models.Equipment;
using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly Guid _userId;
        private readonly int _characterId;

        public EquipmentService(Guid userId)
        {
            _userId = userId;
        }

        public EquipmentService(Guid userId, int id)
        {
            _userId = userId;
            _characterId = id;
        }

        public bool CreateEquipment(EquipmentCreate model)
        {
            var entity = new Equipment()
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
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EquipmentListItem> GetEquipments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Equipments
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                             e =>
                                new EquipmentListItem
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

        public EquipmentDetails GetEquipmentById(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                      ctx
                         .Equipments
                         .Single(e => e.ItemID == itemId && e.OwnerID == _userId);
                return
                    new EquipmentDetails
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

        public bool UpdateEquipment(EquipmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Equipments
                            .Single(e => e.ItemID == model.ItemID && e.OwnerID == _userId);

                
                entity.ItemName = model.ItemName;
                entity.ItemType = model.ItemType;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemValue = model.ItemValue;
                entity.Currency = model.Currency;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEquipment(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Equipments
                            .Single(e => e.ItemID == equipmentId && e.OwnerID == _userId);
                ctx.Equipments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
