using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.ExceptionHandled = true;
            //Log the error!!
            Logger.Error(filterContext.Exception);
            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        }
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }



    }
}