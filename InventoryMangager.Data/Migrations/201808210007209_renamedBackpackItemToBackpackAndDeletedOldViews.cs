namespace InventoryMangager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedBackpackItemToBackpackAndDeletedOldViews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BackpackItem", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.BackpackItem", "ItemID", "dbo.Equipment");
            DropIndex("dbo.BackpackItem", new[] { "CharacterID" });
            DropIndex("dbo.BackpackItem", new[] { "ItemID" });
            CreateTable(
                "dbo.Backpack",
                c => new
                    {
                        BackpackID = c.Int(nullable: false, identity: true),
                        CharacterID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BackpackID)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .ForeignKey("dbo.Equipment", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.CharacterID)
                .Index(t => t.ItemID);
            
            DropTable("dbo.BackpackItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BackpackItem",
                c => new
                    {
                        BackpackID = c.Int(nullable: false, identity: true),
                        CharacterID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        ItemName = c.String(nullable: false),
                        ItemType = c.Int(nullable: false),
                        ItemDescription = c.String(nullable: false),
                        ItemValue = c.Int(nullable: false),
                        Currency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BackpackID);
            
            DropForeignKey("dbo.Backpack", "ItemID", "dbo.Equipment");
            DropForeignKey("dbo.Backpack", "CharacterID", "dbo.Character");
            DropIndex("dbo.Backpack", new[] { "ItemID" });
            DropIndex("dbo.Backpack", new[] { "CharacterID" });
            DropTable("dbo.Backpack");
            CreateIndex("dbo.BackpackItem", "ItemID");
            CreateIndex("dbo.BackpackItem", "CharacterID");
            AddForeignKey("dbo.BackpackItem", "ItemID", "dbo.Equipment", "ItemID", cascadeDelete: true);
            AddForeignKey("dbo.BackpackItem", "CharacterID", "dbo.Character", "CharacterID", cascadeDelete: true);
        }
    }
}
