namespace AngMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "CountryId");
            AddForeignKey("dbo.People", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "CountryId", "dbo.Countries");
            DropIndex("dbo.People", new[] { "CountryId" });
            DropColumn("dbo.People", "CountryId");
        }
    }
}
