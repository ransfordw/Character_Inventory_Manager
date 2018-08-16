using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangager.Data
{
    //public enum CharacterClass { Ranger, Rogue, Cleric}
    
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string  CharacterName { get; set; }

        [Required]
        public string CharacterClass { get; set; }

        [Required]
        public string CharacterRace { get; set; }
    }
}
