using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class CharacterCreate
    {
        [Required]
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }
        public string CharacterRace { get; set; }

        public override string ToString() => CharacterName;
    }
}
