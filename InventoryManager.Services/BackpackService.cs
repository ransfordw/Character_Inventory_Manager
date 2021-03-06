﻿using InventoryManager.Contracts;
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
    public class BackpackService : IBackpackService
    {
        private readonly Guid _userId;
        private List<CharacterBackpackList> _characterBackpackItems = new List<CharacterBackpackList>();
        private List<CharacterBackpackList> _queryableList = new List<CharacterBackpackList>();
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
                                        ItemID = e.ItemID,
                                        CharacterName = e.Character.CharacterName,
                                        ItemName = e.Item.ItemName,
                                    }
                            );
                return query.ToArray();
            }
        }

        public CharacterBackpackList GetBackpackItemByCharacterId(int charId, int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Characters
                            .Single(e => e.CharacterID == charId && e.OwnerID == _userId);
                var itemEntity =
                        ctx
                            .Items
                            .Single(i => i.ItemID == itemId && i.OwnerID == _userId);
                return
                        new CharacterBackpackList
                        {
                            ItemID = itemEntity.ItemID,
                            CharacterName = entity.CharacterName,
                            ItemType = itemEntity.ItemType,
                            ItemName = itemEntity.ItemName,
                            ItemDescription = itemEntity.ItemDescription,
                            ItemValue = itemEntity.ItemValue,
                            Currency = itemEntity.Currency,
                        };
            }
        }

        public BackpackList GetBackpackItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Backpacks
                            .Single(e => e.BackpackID == id && e.OwnerID == _userId);
                return
                        new BackpackList
                        {
                            BackpackID = entity.BackpackID,
                            CharacterID = entity.CharacterID,
                            ItemID = entity.ItemID,
                            CharacterName = entity.Character.CharacterName,
                            ItemName = entity.Item.ItemName,
                            ItemDescription = entity.Item.ItemDescription,
                            ItemType = entity.Item.ItemType,
                            ItemValue = entity.Item.ItemValue,
                            Currency = entity.Item.Currency,
                        };
            }
        }

        public TitleView GetCharacterBackpack(int id, string characterName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach (Backpack backpack in ctx.Backpacks.AsNoTracking().Where(b => b.CharacterID == id).ToList())
                {
                    var query = ctx.Items
                        .AsNoTracking()
                        .Where(i => i.ItemID == backpack.ItemID)
                        .Select(
                               i =>
                               new CharacterBackpackList
                               {
                                   ItemID = i.ItemID,
                                   CharacterName = backpack.Character.CharacterName,
                                   ItemType = i.ItemType,
                                   ItemName = i.ItemName,
                                   ItemDescription = i.ItemDescription,
                                   ItemValue = i.ItemValue,
                                   Currency = i.Currency,
                                   BackpackID = backpack.BackpackID,
                               }
                        );
                    _queryableList = query.ToList();
                    foreach (var item in _queryableList)
                    {
                        _characterBackpackItems.Add(item);
                    }
                }
                TitleView titleView = new TitleView();
                titleView.BackpackItemList = _characterBackpackItems;
                titleView.CharacterName = characterName;
                return titleView;
            }
        }

        public bool DeleteBackpack(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Backpacks
                            .Single(e => e.BackpackID == id && e.OwnerID == _userId);
                ctx.Backpacks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}