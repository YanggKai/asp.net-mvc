using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalMVC.ViewModel;

namespace TotalMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            return View();
        }
        
        
        public ActionResult About()
        {
            var data = from student in db.Students
                       group student by student.Birth into DateGroup
                       select new BirthDateGroup()
                       {
                           Birth = DateGroup.Key,
                           StudentCount = DateGroup.Count()
                       };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}