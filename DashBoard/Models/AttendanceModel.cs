using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashBoard.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }
        public bool IsPresenet { get; set; }
        public bool IsAbsent { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}