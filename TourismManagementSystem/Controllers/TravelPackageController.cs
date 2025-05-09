using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismManagementSystem.DAL;

namespace TourismManagementSystem.Controllers
{
    public class TravelPackageController : Controller
    {
        private TourismContext db = new TourismContext();
        // GET: TravelPackage
        public ActionResult Edit(int id)
        {
            var package = db.TravelPackages.Find(id);
            if (package == null)
                return HttpNotFound();
            return View(package);
        }

        [HttpPost]
        public ActionResult Edit(TravelPackageController updatedPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updatedPackage).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPackages");
            }
            return View(updatedPackage);
        }

        public ActionResult Delete(int id)
        {
            var package = db.TravelPackages.Find(id);
            if (package == null)
                return HttpNotFound();

            return View(package);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var package = db.TravelPackages.Find(id);
            db.SaveChanges();
            return RedirectToAction("MyPackages");
    
        }
    }
}