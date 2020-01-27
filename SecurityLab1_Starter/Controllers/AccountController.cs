using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class AccountController : Controller
    {

        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                 //Write to a file when user loggin 
                        Logger l = new Logger();
                        using (StreamWriter w = System.IO.File.AppendText("C:\\Temp\\useraccess.log"))
                        {
                        l.LogToFile(", " + model.UserName + ", logged in,", w);
                    }
                   

                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {

                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            //Write to a file when user loggin 
            Logger l = new Logger();
            using (StreamWriter w = System.IO.File.AppendText("C:\\Temp\\useraccess.log"))
            {
                l.LogToFile(", "+System.Web.HttpContext.Current.User.Identity.Name + ", logged out,", w);
            }
            authProvider.DeAuthenticate();
            return RedirectToAction("Index","Home",null);
        }
    }
}
