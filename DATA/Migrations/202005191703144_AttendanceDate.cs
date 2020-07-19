namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendanceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendance", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendance", "Date");
        }
    }
}
