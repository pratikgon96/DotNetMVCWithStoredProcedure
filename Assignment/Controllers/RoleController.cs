using Assignment.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        private RoleServices _roleServices;

        public ActionResult Roles()
        {
            _roleServices = new RoleServices();
            var model = _roleServices.GetRole();
            return View(model);
        }

    }
}