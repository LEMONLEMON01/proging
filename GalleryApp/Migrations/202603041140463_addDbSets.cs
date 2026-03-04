namespace GalleryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDbSets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Move_history", "location_from_Id", "dbo.Locations");
            DropForeignKey("dbo.Move_history", "location_to_Id", "dbo.Locations");
            DropPrimaryKey("dbo.Locations");
            CreateTable(
                "dbo.Exhibitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street_Name = c.String(),
                        House_Number = c.Int(nullable: false),
                        City = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Locations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Locations", "Id");
            CreateIndex("dbo.Locations", "Id");
            AddForeignKey("dbo.Locations", "Id", "dbo.Exhibitions", "Id");
            AddForeignKey("dbo.Move_history", "location_from_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Move_history", "location_to_Id", "dbo.Locations", "Id");
            DropColumn("dbo.Locations", "Street_Name");
            DropColumn("dbo.Locations", "House_Number");
            DropColumn("dbo.Locations", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "City", c => c.String(maxLength: 250));
            AddColumn("dbo.Locations", "House_Number", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "Street_Name", c => c.String());
            DropForeignKey("dbo.Move_history", "location_to_Id", "dbo.Locations");
            DropForeignKey("dbo.Move_history", "location_from_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Id", "dbo.Exhibitions");
            DropIndex("dbo.Locations", new[] { "Id" });
            DropPrimaryKey("dbo.Locations");
            AlterColumn("dbo.Locations", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Exhibitions");
            AddPrimaryKey("dbo.Locations", "Id");
            AddForeignKey("dbo.Move_history", "location_to_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Move_history", "location_from_Id", "dbo.Locations", "Id");
        }
    }
}
