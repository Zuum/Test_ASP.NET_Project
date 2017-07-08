namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        city = c.String(),
                        age = c.Int(nullable: false),
                        score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PersonCommunications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        phone = c.String(),
                        isUsed = c.Boolean(nullable: false),
                        Person_id = c.Int(),
                        PhoneType_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Person_id)
                .ForeignKey("dbo.PhoneTypes", t => t.PhoneType_id)
                .Index(t => t.Person_id)
                .Index(t => t.PhoneType_id);
            
            CreateTable(
                "dbo.PhoneTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        phoneType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PersonOperations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        account = c.String(),
                        operationType = c.Int(nullable: false),
                        amount = c.Double(nullable: false),
                        Person_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Person_id)
                .Index(t => t.Person_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonOperations", "Person_id", "dbo.People");
            DropForeignKey("dbo.PersonCommunications", "PhoneType_id", "dbo.PhoneTypes");
            DropForeignKey("dbo.PersonCommunications", "Person_id", "dbo.People");
            DropIndex("dbo.PersonOperations", new[] { "Person_id" });
            DropIndex("dbo.PersonCommunications", new[] { "PhoneType_id" });
            DropIndex("dbo.PersonCommunications", new[] { "Person_id" });
            DropTable("dbo.PersonOperations");
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.PersonCommunications");
            DropTable("dbo.People");
        }
    }
}
