using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class CharacterDetail
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }
        public string CharacterRace { get; set; }

        public override string ToString() => $"[{CharacterID}] {CharacterName}";
    }
}
