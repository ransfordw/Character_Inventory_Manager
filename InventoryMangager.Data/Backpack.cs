using System;
using System.ComponentModel.DataAnnotations;

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

        //Add extended properties for bonus features for a specific characters items i.e. a blade gets cursed and gains the ghost-touch property
        public virtual Character Character { get; set; }
        public virtual Item Item { get; set; }
    }
}