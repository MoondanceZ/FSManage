﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FSManage.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             base.OnActionExecuting(filterContext);
            if (Session["userInfo"] == null)
            {
                filterContext.Result = Redirect("/FSManage/Login");
            }
        }
    }
}
