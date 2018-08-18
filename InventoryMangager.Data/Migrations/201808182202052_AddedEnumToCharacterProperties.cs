namespace InventoryMangager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnumToCharacterProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Character", "CharacterClass", c => c.Int(nullable: false));
            AlterColumn("dbo.Character", "CharacterRace", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Character", "CharacterRace", c => c.String(nullable: false));
            AlterColumn("dbo.Character", "CharacterClass", c => c.String(nullable: false));
        }
    }
}
