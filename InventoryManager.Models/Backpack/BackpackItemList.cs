using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Backpack
{
    public class BackpackItemList
    {
        [Key]
        public int BackpackID { get; set; }

        [ForeignKey("CharacterID")]
        public int CharacterID { get; set; }

        [Display(Name = "Item")]
        public string ItemName { get; set; }

        [Display(Name = "Type")]
        public ItemType ItemType { get; set; }

        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Value")]
        public int ItemValue { get; set; }

        public Currency Currency { get; set; }
    }
}
