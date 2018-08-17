namespace InventoryMangager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEquipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        ItemName = c.String(nullable: false),
                        ItemType = c.Int(nullable: false),
                        ItemDescription = c.String(nullable: false),
                        ItemValue = c.Int(nullable: false),
                        Currency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Equipment");
        }
    }
}
