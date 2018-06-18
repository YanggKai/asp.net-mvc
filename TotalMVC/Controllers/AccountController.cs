using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TotalMVC.Models;

namespace TotalMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        SchoolContext db = new SchoolContext();
        //public ActionResult AIndex()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AIndex(string username, string password)
        //{
        //    //var FindUser = from f in db.Accounts
        //    //               where f.UserName == username
        //    //               select f;

        //    var Accounts = new Account[]
        //    {
        //       new Account{UserName=username,Password=password}
        //    };
        //    foreach (var a in Accounts)
        //    {
        //        db.Accounts.Add(a);
        //    }

        //    db.SaveChanges();

        //    return View("~/Views/Account/Test.cshtml");
        //}

        //GET: AIndex()
        public ActionResult AIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AIndex([Bind(Include = "UserName,Password")] Account account, string username)
        {
            var distinct = from d in db.Accounts
                           select d;
            foreach (var f in distinct)
            {
                if (username == f.UserName)
                {
                    ModelState.AddModelError("UserName", "这个用户名已经存在");
                }

            }
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Test");
            }


            return View(account);
        }

        //GET:Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password")] Account account,
           string username, string password, string yanzhengma,string code)
        {
            string Judge=null;
            var validate = from v in db.Accounts
                           where v.UserName==username&&v.Password==password
                           select v;

            foreach(var i in validate )
            {
                Judge = i.UserName;
            }
            List<string> getValidator = new List<string> { GetValidator(null) };
            List<string> inputs = new List<string> { yanzhengma };

            ViewBag.Message = getValidator[0];

            if (!string.IsNullOrEmpty(Judge))
            {
                if(code==inputs[0])
                {
                    return RedirectToAction("Test");
                }
                else
                {
                    ModelState.AddModelError("yanzhengma", "验证码错误");
                }
            }
            else
            {
                ModelState.AddModelError("password", "用户名或密码错误");
            }
            ViewBag.code = code;
            return View();
        }
        /// <summary>
        /// 用于随机验证码
        /// </summary>
        /// <returns></returns>
        public static string GetValidator(string s)
        {
            Random rd = new Random();
            for (int i = 0; i < 4; i++)
            {
                s += rd.Next(0, 9);
            }
            return s;
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult CopyMs()
        {
            return View();
        }

        public ActionResult Tes11t()
        {
            ValidateCode vc = new ValidateCode();
            string vCode = vc.CreateValidateCode(4);
            ViewBag.Message = vCode;
            byte[] bytes = vc.CreateValidateGraphic(vCode);
            return File(bytes, @"image|jpeg");
        }

    }
}

