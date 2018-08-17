using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.CharacterModels
{
    public class CharacterEdit
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }
        public string CharacterRace { get; set; }
    }
}
