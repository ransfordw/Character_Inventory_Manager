using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Backpack
{
    public class BackpackCreate
    {
        public int CharacterID { get; set; }
        public int ItemID { get; set; }
        
    }
}
