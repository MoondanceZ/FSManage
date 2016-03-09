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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            try
            {
                string loginId = Request["loginId"] ?? "";
                string passWord = Request["passWord"] ?? "";
                FSManageDbContext db = new FSManageDbContext();
                var user = db.AdminUser.Where(u => u.LoginId == loginId && u.Password == passWord).FirstOrDefault();
                if (user != null)
                {
                    Session["userInfo"] = user;
                    return Content("ok");
                }
                else
                    return Content("fail");
            }
            catch
            {

            }
            return null;
        }

        public ActionResult Quit()
        {
            Session["userInfo"] = null;
            return RedirectToAction("Login", "FSManage");
        }
    }
}