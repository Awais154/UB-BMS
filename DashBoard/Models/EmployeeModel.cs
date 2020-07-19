using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DashBoard.Models
{
    public class EmployeeModel
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(12)]
        public string CellNo { get; set; }
        [Required]
        [MaxLength(20)]
        public string CNIC { get; set; }
        public DateTime CreatedOn { get; set; }
        public int DepartmentId { get; set; }

    }

    //public class DepartmentModel
    //{
    //    public int DepartmentId { get; set; }
    //    public string Name { get; set; }
    //}
}