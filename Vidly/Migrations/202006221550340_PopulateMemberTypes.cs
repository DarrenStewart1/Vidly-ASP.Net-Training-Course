namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberTypes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "membershipTypeId" });
            CreateIndex("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            CreateIndex("dbo.Customers", "membershipTypeId");
        }
    }
}
