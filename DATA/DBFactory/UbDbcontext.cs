using DATA.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DBFactory
{
    public class UbDbcontext : DbContext
    {
        public UbDbcontext() : base("constring")
        { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Height> Height { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tell Code First to ignore PluralizingTableName convention
            // If you keep this convention then the generated tables will have pluralized names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Disable the default cascade behaviour of entity framework
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Employee>().HasRequired(x => x.Department).WithMany(x => x.DepartmentName).HasForeignKey(x => x.TradeMarkId).WillCascadeOnDelete(true);

        }
    }
}

