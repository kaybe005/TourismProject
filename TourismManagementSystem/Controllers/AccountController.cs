using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismManagementSystem.DAL;
using TourismManagementSystem.Models;

namespace TourismManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private TourismContext db = new TourismContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            
                db.Users.Add(user);
                db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.FullName;
                Session["UserRole"] = user.Role;

                if (user.Role == "Agency")
                    return RedirectToAction("Dashboard", "Agency");
                else
                    return RedirectToAction("Dashboard", "Tourist");
            }
            ViewBag.Message = "Invalid credentials.";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}