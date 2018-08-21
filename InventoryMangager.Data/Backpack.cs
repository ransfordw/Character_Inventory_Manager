using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangager.Data
{
    
    public class Backpack
    {
        [Key]
        public int BackpackID { get; set; }

        public int CharacterID { get; set; }

        public int ItemID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        public virtual Character Character { get; set; }
        public virtual Item Item { get; set; }
    }
}
