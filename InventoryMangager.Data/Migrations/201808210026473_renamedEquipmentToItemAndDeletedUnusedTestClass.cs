namespace InventoryMangager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedEquipmentToItemAndDeletedUnusedTestClass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Equipment", newName: "Item");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Item", newName: "Equipment");
        }
    }
}
