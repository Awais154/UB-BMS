namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        IsPresenet = c.Boolean(nullable: false),
                        IsAbsent = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Attendance", new[] { "EmployeeId" });
            DropTable("dbo.Attendance");
        }
    }
}
