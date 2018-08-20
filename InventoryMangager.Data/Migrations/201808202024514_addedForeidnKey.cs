namespace InventoryMangager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeidnKey : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.BackpackID)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .ForeignKey("dbo.Equipment", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.CharacterID)
                .Index(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BackpackItem", "ItemID", "dbo.Equipment");
            DropForeignKey("dbo.BackpackItem", "CharacterID", "dbo.Character");
            DropIndex("dbo.BackpackItem", new[] { "ItemID" });
            DropIndex("dbo.BackpackItem", new[] { "CharacterID" });
            DropTable("dbo.BackpackItem");
        }
    }
}
