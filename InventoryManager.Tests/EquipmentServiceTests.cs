using System;
using InventoryManager.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryManager.Tests
{
    [TestClass]
    public class EquipmentServiceTests : IEquipmentService
    {
        public bool CreateEquipment(InventoryManager.Models.Equipment.EquipmentCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEquipment(int equipmentId)
        {
            throw new NotImplementedException();
        }

        public InventoryManager.Models.Equipment.EquipmentDetails GetEquipmentById(int itemId)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<InventoryManager.Models.Equipment.EquipmentListItem> GetEquipments()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        public bool UpdateEquipment(InventoryManager.Models.Equipment.EquipmentEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
