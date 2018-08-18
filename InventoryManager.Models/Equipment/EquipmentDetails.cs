using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Equipment
{
    public class EquipmentDetails
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public string ItemDescription { get; set; }
        public int ItemValue { get; set; }
        public Currency Currency { get; set; }

        public override string ToString() => $"[{ItemID }] {ItemName }";
    }
}
