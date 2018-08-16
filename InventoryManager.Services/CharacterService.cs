using InventoryManager.Data;
using InventoryManager.Models;
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
    }
}
