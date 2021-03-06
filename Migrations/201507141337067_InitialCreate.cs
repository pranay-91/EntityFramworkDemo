namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Standard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Standards", t => t.Standard_Id)
                .Index(t => t.Standard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Standard_Id", "dbo.Standards");
            DropIndex("dbo.Students", new[] { "Standard_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Standards");
        }
    }
}
