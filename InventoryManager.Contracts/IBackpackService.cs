using InventoryManager.Models.Backpack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Contracts
{
    public interface IBackpackService
    {
        bool CreateBackpack(BackpackCreate model);
        IEnumerable<BackpackList> GetBackpacks();
        CharacterBackpackList GetBackpackItemByCharacterId(int charId, int itemId);
        TitleView GetCharacterBackpack(int id, string characterName);
        bool DeleteBackpack(int backpackId);
    }
}