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
    public class BackpackList
    {
        public int BackpackID { get; set; }
        public int CharacterID { get; set; }
        public int ItemID { get; set; }

        public string CharacterName { get; set; }
        public string ItemName { get; set; }
        //[Required]
        //[Display(Name = "Item Name")]
        //public string ItemName { get; set; }

        //[Required]
        //[Display(Name = "Type of Item")]
        //public ItemType ItemType { get; set; }

        //[Required]
        //[Display(Name = "Description")]
        //public string ItemDescription { get; set; }

        //[Required]
        //[Display(Name = "Value")]
        //public int ItemValue { get; set; }

        //[Required]
        //public Currency Currency { get; set; }

    }
}
