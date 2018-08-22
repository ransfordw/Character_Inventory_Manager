using InventoryManager.Data;
using InventoryManager.Models.Backpack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class CharacterBackpackService
    {
        private readonly Guid _userId;

        public CharacterBackpackService(Guid userId)
        {
            _userId = userId;
        }


        //public IEnumerable<CharacterBackpackList> GetBackpacksByCharacterId()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //                ctx
        //                    .Backpacks
        //                    .Where(e => e.OwnerID == _userId)
        //                    .Select(
        //                        e =>
        //                            new CharacterBackpackList
        //                            {
        //                                BackpackID = e.BackpackID,
        //                                CharacterID = e.CharacterID,
        //                                CharacterName = e.CharacterName,
        //                            }
        //                    );
        //        return query.ToArray();
        //    }
        //}
    }
}
