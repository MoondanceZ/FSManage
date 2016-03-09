using FSManage.Common;
using FSManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FSManage.Controllers
{
    public class UserInfoController : BaseController
    {
        // GET: UserInfo
        FSManageDbContext db = new FSManageDbContext();
        public ActionResult Index()
        {
            int pageIndex;
            if (!int.TryParse(Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 6;
            int recordCount = 0;
            List<UserInfo> userList = null;
            string uid = Request["uid"] ?? String.Empty;
            if (String.IsNullOrEmpty(uid))
            {
                userList = CommonBase.GetPageList<UserInfo>(u => true, u => u.Id, pageIndex, pageSize, db);
                recordCount = db.UserInfo.Where(u => true).Count();
            }
            else
            {
                userList = CommonBase.GetPageList<UserInfo>(u => u.LoginId.Contains(uid), u => u.Id, pageIndex, pageSize, db);
                recordCount = db.UserInfo.Where(u => u.LoginId.Contains(uid)).ToList().Count;
            }
            //计算总记录数            
            int pageCount = Convert.ToInt32(Math.Ceiling((decimal)recordCount / pageSize));
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = pageCount;
            ViewBag.PageBar = CommonBase.GetPageBar(pageIndex, pageCount);
            ViewData.Model = userList;
            ViewBag.UserInfo = Session["userInfo"];
            //加载用户类型下拉框
            var uTypeList = from u in db.UType
                            orderby u.Id
                            select new { Text = u.Name, Value = u.Id };
            ViewBag.UType = new SelectList(uTypeList.ToList(), "Value", "Text", 1);
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserInfo userInfo)
        {
            FSManageDbContext db = new FSManageDbContext();
            userInfo.RegTime = DateTime.Now;
            userInfo.Guid = System.Guid.NewGuid().ToString();
            db.UserInfo.Add(userInfo);
            int count = db.SaveChanges();
            if (count > 0)
                return RedirectToAction("Index", "UserInfo");
            else
                return Content("添加失败!");
        }

        public ActionResult Search()
        {
            string uid = Request["uid"];
            var userList = db.UserInfo.Where(u => u.LoginId.Contains(uid));
            if (userList.Count() > 0)
            {
                return RedirectToAction("Index", "UserInfo", new { uid = uid });
            }
            return Content("查无此用户!");
        }

        public ActionResult Delete(int id)
        {
            var user = db.UserInfo.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                db.Entry<UserInfo>(user).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index", "UserInfo");
            }
            else
            {
                return Content("删除失败!");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.UserInfo.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry<UserInfo>(userInfo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = userInfo.Id });
            }
            return View(userInfo);
        }

        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.UserInfo.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
