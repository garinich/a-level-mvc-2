namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DBSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emploees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false),
                        City = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emploees");
        }
    }
}
