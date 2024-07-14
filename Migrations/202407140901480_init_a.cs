namespace MVCwithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Age = c.String(),
                        DOB = c.String(),
                        Gender = c.String(),
                        Occupation = c.String(),
                        Email = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
