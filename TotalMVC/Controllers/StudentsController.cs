using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TotalMVC;
using TotalMVC.Models;

namespace TotalMVC.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Students
        public ActionResult Index(string searchString, string searchGenre, string sortOrder,int? page,string currentFilter)
        {
            //排序
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortName = string.IsNullOrEmpty(sortOrder) ? "Desc_Name" : "";
            ViewBag.SortAge = sortOrder == "Date" ? "Desc_Date" : "Date";

            ViewBag.Message = searchString;

            var search = from s in db.Students
                         select s;
            if (searchString != null)
            {
                page = 1;
            }
            //else
            //{
            //    searchString = currentFilter;
            //}
            ViewBag.currentFilter = searchString;
            ViewBag.GetPage = page;
           
            if (!string.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Desc_Name":
                    search = search.OrderByDescending(s => s.Name);
                    break;
                case "Desc_Date":
                    search = search.OrderByDescending(s => s.Age);
                    break;
                case "Date":
                    search = search.OrderBy(s => s.Age);
                    break;
                default:
                    search = search.OrderBy(s => s.Name);
                    break;
            }

            var generList = new List<string>();

            var getGenre = from g in db.Students
                           orderby g.Re
                           select g.Re;
            generList.AddRange(getGenre);
            ViewBag.searchGenre = new SelectList(generList);



            if (!string.IsNullOrEmpty(searchGenre))
            {
                search = search.Where(g => g.Re == searchGenre);
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(search.ToPagedList(pageNumber, pageSize));

            return View(search);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Age,Name,Birth")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Birth,Age,Re")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
