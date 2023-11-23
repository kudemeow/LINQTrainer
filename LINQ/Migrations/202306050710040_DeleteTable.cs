namespace LINQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Number_exercise = c.Int(nullable: false),
                        Number_temi = c.Int(nullable: false),
                        Exercise_description = c.String(nullable: false, unicode: false, storeType: "text"),
                        Etal_zapros = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Number_exercise)
                .ForeignKey("dbo.Topic", t => t.Number_temi, cascadeDelete: true)
                .Index(t => t.Number_temi);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id_user = c.Int(nullable: false),
                        Number_exercise = c.Int(nullable: false),
                        Result = c.Boolean(nullable: false),
                        Progress = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => new { t.Id_user, t.Number_exercise })
                .ForeignKey("dbo.Exercises", t => t.Number_exercise, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id_user, cascadeDelete: true)
                .Index(t => t.Id_user)
                .Index(t => t.Number_exercise);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id_user = c.Int(nullable: false),
                        Login_user = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password_user = c.String(nullable: false, maxLength: 30, unicode: false),
                        Level_dostup = c.Boolean(nullable: false),
                        First_name = c.String(nullable: false, maxLength: 20, unicode: false),
                        Second_name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Father_name = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id_user);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Number_temi = c.Int(nullable: false),
                        Name_temi = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Number_temi);
            
            CreateTable(
                "dbo.Theory",
                c => new
                    {
                        IDTheory = c.Int(nullable: false),
                        IDTopic = c.Int(nullable: false),
                        TextTopic = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IDTheory, t.IDTopic, t.TextTopic });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "Number_temi", "dbo.Topic");
            DropForeignKey("dbo.Results", "Id_user", "dbo.Users");
            DropForeignKey("dbo.Results", "Number_exercise", "dbo.Exercises");
            DropIndex("dbo.Results", new[] { "Number_exercise" });
            DropIndex("dbo.Results", new[] { "Id_user" });
            DropIndex("dbo.Exercises", new[] { "Number_temi" });
            DropTable("dbo.Theory");
            DropTable("dbo.Topic");
            DropTable("dbo.Users");
            DropTable("dbo.Results");
            DropTable("dbo.Exercises");
        }
    }
}
