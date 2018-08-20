using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Backpack
{
    public class BackpackItemDetails
    {
        public int BackpackID { get; set; }

        public int CharacterID { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Type")]
        public ItemType ItemType { get; set; }

        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Value")]
        public int ItemValue { get; set; }

        public Currency Currency { get; set; }

        public override string ToString() => $"[{BackpackID }] {ItemName }";
    }
}
