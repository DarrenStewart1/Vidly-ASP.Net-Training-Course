namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDobToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.String());
        }
    }
}
