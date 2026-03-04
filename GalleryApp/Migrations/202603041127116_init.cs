namespace GalleryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date_of_birth = c.DateTime(nullable: false),
                        full_name = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Move_history",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        location_from_Id = c.Int(),
                        location_to_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.location_from_Id)
                .ForeignKey("dbo.Locations", t => t.location_to_Id)
                .Index(t => t.location_from_Id)
                .Index(t => t.location_to_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Street_Name = c.String(),
                        House_Number = c.Int(nullable: false),
                        City = c.String(maxLength: 250),
                        Painting_Id = c.Int(),
                        Painting_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id1)
                .Index(t => t.Painting_Id)
                .Index(t => t.Painting_Id1);
            
            CreateTable(
                "dbo.Paintings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Author_Id = c.Int(),
                        Cost = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Move_history_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Move_history", t => t.Move_history_Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id )
                .Index(t => t.Move_history_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Move_historyEmployee",
                c => new
                    {
                        Move_history_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Move_history_Id, t.Employee_Id })
                .ForeignKey("dbo.Move_history", t => t.Move_history_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Move_history_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.GenrePaintings",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Painting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Painting_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Painting_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        Accesses = c.String(maxLength: 200),
                        login = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Year_of_birth = c.Int(nullable: false),
                        Year_of_death = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authors", "Id", "dbo.People");
            DropForeignKey("dbo.Employees", "Id", "dbo.People");
            DropForeignKey("dbo.Paintings", "Move_history_Id", "dbo.Move_history");
            DropForeignKey("dbo.Locations", "Painting_Id1", "dbo.Paintings");
            DropForeignKey("dbo.GenrePaintings", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.GenrePaintings", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Locations", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.Move_history", "location_to_Id", "dbo.Locations");
            DropForeignKey("dbo.Move_history", "location_from_Id", "dbo.Locations");
            DropForeignKey("dbo.Move_historyEmployee", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Move_historyEmployee", "Move_history_Id", "dbo.Move_history");
            DropForeignKey("dbo.People", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Authors", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.GenrePaintings", new[] { "Painting_Id" });
            DropIndex("dbo.GenrePaintings", new[] { "Genre_Id" });
            DropIndex("dbo.Move_historyEmployee", new[] { "Employee_Id" });
            DropIndex("dbo.Move_historyEmployee", new[] { "Move_history_Id" });
            DropIndex("dbo.Paintings", new[] { "Move_history_Id" });
            DropIndex("dbo.Locations", new[] { "Painting_Id1" });
            DropIndex("dbo.Locations", new[] { "Painting_Id" });
            DropIndex("dbo.Move_history", new[] { "location_to_Id" });
            DropIndex("dbo.Move_history", new[] { "location_from_Id" });
            DropIndex("dbo.People", new[] { "Author_Id" });
            DropTable("dbo.Authors");
            DropTable("dbo.Employees");
            DropTable("dbo.GenrePaintings");
            DropTable("dbo.Move_historyEmployee");
            DropTable("dbo.Genres");
            DropTable("dbo.Paintings");
            DropTable("dbo.Locations");
            DropTable("dbo.Move_history");
            DropTable("dbo.People");
        }
    }
}
