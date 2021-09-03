using Assignment.DBServices;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class ProjectEmployeeController : Controller
    {
        // GET: ProjectEmployee
        private ProjectEmployeeServices _proempServices;
        // GET: Project
        public ActionResult ProjectEmployee()
        {
            _proempServices = new ProjectEmployeeServices();
            var model = _proempServices.GetProjectEmployee();
            return View(model);
        }

        public ActionResult AddProjectEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProjectEmployee(ProjectEmployee model)
        {
            _proempServices = new ProjectEmployeeServices();
            _proempServices.InsertProjectEmployee(model);
            return RedirectToAction("ProjectEmployee");
        }
    }
}