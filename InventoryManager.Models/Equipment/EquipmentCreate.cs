using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Equipment
{
    public class EquipmentCreate
    {
        [Required]
        public string ItemName { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public int ItemValue { get; set; }

        [Required]
        public Currency Currency { get; set; }

        public override string ToString() => ItemName;
    }
}
