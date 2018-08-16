namespace InventoryMangager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedEnumToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Character", "CharacterClass", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Character", "CharacterClass", c => c.Int(nullable: false));
        }
    }
}
