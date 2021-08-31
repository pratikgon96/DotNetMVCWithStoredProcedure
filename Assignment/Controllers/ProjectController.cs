using Assignment.DBServices;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectServices _proServices;
        // GET: Project
        public ActionResult Projects()
        {
            _proServices = new ProjectServices();
            var model = _proServices.GetProject();
            return View(model);
        }

        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project model)
        {
            _proServices = new ProjectServices();
            _proServices.InsertProject(model);
            return RedirectToAction("Projects");
        }

        public ActionResult GetProjectById(int Id)
        {
            _proServices = new ProjectServices();
            var model = _proServices.GetProjectById(Id);
            return View(model);
        }

        public ActionResult ManageProject(int id)
        {
            _proServices = new ProjectServices();
            var model = _proServices.GetProjectById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ManageProject(Project model)
        {
            _proServices = new ProjectServices();
            _proServices.UpdateProject(model);
            return RedirectToAction("Projects");
        }
    }
}