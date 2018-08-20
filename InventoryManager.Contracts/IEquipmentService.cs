using InventoryManager.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Contracts
{
    public interface IEquipmentService
    {
        
        bool CreateEquipment(EquipmentCreate model);
        IEnumerable<EquipmentListItem> GetEquipments();
        EquipmentDetails GetEquipmentById(int itemId);
        bool UpdateEquipment(EquipmentEdit model);
        bool DeleteEquipment(int equipmentId);

    }
}
