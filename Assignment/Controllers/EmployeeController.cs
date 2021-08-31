 using Assignment.DBServices;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private EmpServices _empServices;

        public ActionResult Employees()
        {
            _empServices = new EmpServices();
            var model = _empServices.GetEmployees();
            return View(model);
        }

        public ActionResult EmployeesById(int roleid)
        {
            _empServices = new EmpServices();
            var model = _empServices.GetEmployees().Where(emp => emp.RoleId == roleid);
            return View(model);
        }


        public ActionResult GetEmployeeById(int Id)
        {
            _empServices = new EmpServices();
            var model = _empServices.GetEmployeeById(Id);
            return View(model);
        }
        
        public ActionResult ManageRole(int id)
        {
            _empServices = new EmpServices();
            var model = _empServices.GetEmployeeById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ManageRole(Employee model)
        {
            _empServices = new EmpServices();
            _empServices.UpdateEmployee(model);
            return RedirectToAction("Employees");
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            _empServices = new EmpServices();
            _empServices.InsertEmployee(model);
            return RedirectToAction("Employees");
        }
    }
}