using InventoryManager.Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Contracts
{
    public interface ICharacterService
    {
        bool CreateCharacter(CharacterCreate model);
        IEnumerable<CharacterListItem> GetCharacters();
        CharacterDetail GetCharacterById(int characterId);
        bool UpdateCharacter(CharacterEdit model);
        bool DeleteCharacter(int characterId);
        CharacterDetail GetCharacterByIdAgain(int id);
    }
}