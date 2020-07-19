using DashBoard.Models;
using Provider.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashBoard.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeProvider employeeProvider;

        public EmployeeController()
        {
            employeeProvider = new EmployeeProvider();
        }

        #region Action
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployee()
        {
            var departments = employeeProvider.GetDepartments();
            TempData["Departments"] = departments;

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(DashBoard.Models.EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                DATA.Domains.Employee employee = new DATA.Domains.Employee
                {
                    CellNo = model.CellNo,
                    CNIC = model.CNIC,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DepartmentId = model.DepartmentId,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };
                employeeProvider.AddEmployee(employee);

                TempData["alert"] = GetAlert("Employee added successfully", "success");
            }
            else
            {
                TempData["alert"] = GetAlert("Employee not added successfully", "error");
            }

            var departments = employeeProvider.GetDepartments();
            TempData["Departments"] = departments;

            return View();
        }

        public ActionResult GetEmployees()
        {
            var employee = employeeProvider.GetEmployees();

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employeetoEdit = employeeProvider.EditEmployee(id);

            var departments = employeeProvider.GetDepartments();
            TempData["Departments"] = departments;

            return View("Edit", employeetoEdit);
        }

        [HttpPost]
        public ActionResult Update(DATA.Domains.Employee employee)
        {
            try
            {
                employeeProvider.UpdateEmployee(employee);
                TempData["alert"] = GetAlert("Employee updated successfully", "success");
            }
            catch (Exception ex)
            {
                TempData["alert"] = GetAlert(ex.Message, "error");
            }

            return RedirectToAction("GetEmployees");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                employeeProvider.DeleteEmployee(id);
                TempData["alert"] = GetAlert("Employee removed successfully", "success");
            }
            catch (Exception ex)
            {
                TempData["alert"] = GetAlert("Error", ex.Message);
            }

            return RedirectToAction("GetEmployees");
        }
        #endregion

        #region Attendence
        public ActionResult AttendaceSheet()
        {
            var employee = employeeProvider.GetEmployees();

            var lastAttendance = employeeProvider.GetFullAttendance();
            TempData["lastAttendance"] = lastAttendance;

            return View(employee);
        }

        [HttpPost]
        public ActionResult MarkAttendace(DashBoard.Models.AttendanceModel model)
        {
            DATA.Domains.Attendance attendance = new DATA.Domains.Attendance
            {
                EmployeeName = model.EmployeeName,
                IsAbsent = model.IsAbsent,
                IsPresenet = model.IsPresenet,
                EmployeeId = model.EmployeeId,
                Date = DateTime.Now
            };
            employeeProvider.AddAttendace(attendance);
            TempData["alert"] = GetAlert("Marked", "success");

            return RedirectToAction("AttendaceSheet");
        }

        #endregion

        #region private

        private Alerts GetAlert(string alertMessage, string alertType)
        {
            return new Alerts
            {
                AlertMessage = alertMessage,
                AlertType = alertType
            };
        }

        #endregion
    }
}