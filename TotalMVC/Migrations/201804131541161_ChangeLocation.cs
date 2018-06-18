namespace TotalMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Re", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Re");
        }
    }
}
