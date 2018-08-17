using InventoryManager.Data;
using InventoryManager.Models;
using InventoryManager.Models.CharacterModels;
using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class CharacterService
    {
        private readonly Guid _userId;
        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity = new Character()
            {
                OwnerID = _userId,
                CharacterName = model.CharacterName,
                CharacterClass = model.CharacterClass,
                CharacterRace = model.CharacterRace,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new CharacterListItem
                                {
                                    CharacterID = e.CharacterID,
                                    CharacterName = e.CharacterName,
                                    CharacterClass = e.CharacterClass,
                                    CharacterRace = e.CharacterRace,
                                }
                        );
                return query.ToArray();
            }
        }

        public CharacterDetail GetCharacterById(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                      ctx
                         .Characters
                         .Single(e => e.CharacterID == characterId && e.OwnerID == _userId);
                return
                    new CharacterDetail
                    {
                        CharacterID = entity.CharacterID,
                        CharacterName = entity.CharacterName,
                        CharacterClass = entity.CharacterClass,
                        CharacterRace = entity.CharacterRace,
                    };
            }
        }

        public bool UpdateNote(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            { var entity =
                        ctx
                            .Characters
                            .Single(e => e.CharacterID == model.CharacterID && e.OwnerID == _userId);

                entity.CharacterName = model.CharacterName;
                entity.CharacterClass = model.CharacterClass;
                entity.CharacterRace = model.CharacterRace;

                return ctx.SaveChanges() == 1;
            } 
        }

        public bool DeleteCharacter (int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterID == characterId && e.OwnerID == _userId);
                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
