using FSManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSManage.Controllers
{
    public class FSManageController : Controller
    {
        // GET: FSManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["userInfo"] != null)
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(UserInfo userInfo)
        {
            FSManageDbContext db = new FSManageDbContext();
            var user = db.UserInfo.Where(u => u.LoginId == userInfo.LoginId && u.PassWord == userInfo.PassWord).FirstOrDefault();
            if (user != null)
            {
                Session["userInfo"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
                return Content("<script>alter('登陆失败!')</script>");
        }

        public ActionResult Quit()
        {
            Session["userInfo"] = null;
            return RedirectToAction("Login", "FSManage");
        }
    }
}