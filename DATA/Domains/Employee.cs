using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Employee:BaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(12)]
        public string CellNo { get; set; }
        [MaxLength(20)]
        public string CNIC { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
