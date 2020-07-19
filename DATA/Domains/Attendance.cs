using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Domains
{
   public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public bool IsPresenet { get; set; }
        public bool IsAbsent { get; set; }
        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
