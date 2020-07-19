using DATA.Domains;
using DATA.DBFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Provider.Employee;


namespace Provider.Employee
{
    public class EmployeeProvider
    {
        public List<Department> GetDepartments()
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                return context.Department.ToList();
            }
        }

        public void AddEmployee(DATA.Domains.Employee employee)
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                context.Employee.Add(employee);
                context.SaveChanges();
            }
        }

        public List<DATA.Domains.Employee> GetEmployees()
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                return context.Employee.Include("Department").Where(x => x.IsActive).ToList();
            }
        }

        public DATA.Domains.Employee EditEmployee(int id)
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                var employee = context.Employee.Include("Department").Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();

                return employee;
            }
        }

        public void UpdateEmployee(DATA.Domains.Employee employee)
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                var employeeToUpdate = context.Employee.Where(x => x.Id == employee.Id).FirstOrDefault();

                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.CNIC = employee.CNIC;
                employeeToUpdate.CellNo = employee.CellNo;
                employeeToUpdate.DepartmentId = employee.DepartmentId;

                context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                var employeeToDelete = context.Employee.Where(x => x.Id == id).FirstOrDefault();
                employeeToDelete.IsDeleted = true;
                employeeToDelete.IsActive = false;

                context.SaveChanges();
            }
        }

        public void AddAttendace(DATA.Domains.Attendance attendance)
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                try
                {
                    var already = context.Attendance.Where(x => x.EmployeeName == attendance.EmployeeName && x.Date == attendance.Date).ToList();


                    if (!already.Any())
                    {
                        context.Attendance.Add(attendance);

                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        //public DATA.Domains.Attendance GetAttendanceByEmployeeId(int employeeId)
        //{
        //    using (UbDbcontext context = new UbDbcontext())
        //    {
        //        var attendence = context.Attendance.Where(x => x.EmployeeId == employeeId).FirstOrDefault();

        //        return attendence;
        //    }
        //}

        public List<DATA.Domains.Attendance> GetFullAttendance()
        {
            using (UbDbcontext context = new UbDbcontext())
            {
                var attendence = context.Attendance.ToList();

                return attendence;
            }
        }

        //public DateTime GetAttendaceDate(int empId)
        //{
        //    using (UbDbcontext context = new UbDbcontext())
        //    {
        //        var date = context.Attendance.Where(x=>x.EmployeeId==empId).FirstOrDefault();

        //        return date.Date;
        //    }
        //}
    }
}
