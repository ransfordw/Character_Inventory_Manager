using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangager.Data
{
    public enum Currency { Copper, Silver, Gold, Platinum}
    public enum ItemType { Weapon, Armor, Materials, Potions, Misc}
    public class Equipment
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Type of Item")]
        public ItemType ItemType { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Required]
        [Display(Name = "Value")]
        public int ItemValue { get; set; }

        [Required]
        public Currency Currency { get; set; }
    }
}
