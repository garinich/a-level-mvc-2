namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Lang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Lang", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Lang");
        }
    }
}
