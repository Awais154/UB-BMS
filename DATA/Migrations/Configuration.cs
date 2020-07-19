namespace DATA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DATA.DBFactory.UbDbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DATA.DBFactory.UbDbcontext context)
        {
            SeedDepartments(context);
            SeedHeight(context);
            SeedProductType(context);
        }
        private void SeedDepartments(DATA.DBFactory.UbDbcontext context)
        {
            if (!context.Department.Any())
            {
                context.Department.Add(new Domains.Department
                {
                    DepartmentName = "Sales Man",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();
                context.Department.Add(new Domains.Department
                {
                    DepartmentName = "Watch Man",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();

                context.Department.Add(new Domains.Department
                {
                    DepartmentName = "Water Man",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();

                context.Department.Add(new Domains.Department
                {
                    DepartmentName = "Work Shop",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();

                context.Department.Add(new Domains.Department
                {
                    DepartmentName = "Accountant",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();

                context.Department.Add(new Domains.Department
                {
                    DepartmentName = "Owner",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();
            }
        }

        private void SeedHeight(DATA.DBFactory.UbDbcontext context)
        {
            if (!context.Height.Any())
            {
                context.Height.Add(new Domains.Height
                {
                    Name = "Single"
                });
                context.SaveChanges();

                context.Height.Add(new Domains.Height
                {
                    Name = "One_Half"
                });
                context.SaveChanges();

                context.Height.Add(new Domains.Height
                {
                    Name = "Double"
                });
                context.SaveChanges();

                context.Height.Add(new Domains.Height
                {
                    Name = "Tripple"
                });
                context.SaveChanges();

            }
        }

        private void SeedProductType(DATA.DBFactory.UbDbcontext context)
        {
            if (!context.ProductType.Any())
            {
                context.ProductType.Add(new Domains.ProductType
                {
                    Name="Slab",
                    CreatedOn=DateTime.Now
                });
                context.SaveChanges();

                context.ProductType.Add(new Domains.ProductType
                {
                    Name = "Girder",
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();

                context.ProductType.Add(new Domains.ProductType
                {
                    Name = "BWC",
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();
            }
        }
    }
}
