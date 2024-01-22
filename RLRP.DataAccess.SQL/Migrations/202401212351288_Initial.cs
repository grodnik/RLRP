namespace RLRP.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AreaName = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 40),
                        Area = c.String(),
                        Status = c.String(),
                        OldNbr = c.String(),
                        DefinedDate = c.DateTime(nullable: false),
                        BudgetYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetLife = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OddEven = c.String(),
                        Notes = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
            DropTable("dbo.Areas");
        }
    }
}
