using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismManagementSystem.Controllers
{
    public class AgencyController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Agency")
                return RedirectToAction("Login", "Account");

            ViewBag.FullName = Session["FullName"];
            return View();
        }
    }
}