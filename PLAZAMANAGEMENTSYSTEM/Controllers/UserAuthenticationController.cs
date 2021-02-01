using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{

   
    public class UserAuthenticationController : Controller
    {

        public ActionResult Login()

        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Index", "Dashboard", new { username = Session["username"].ToString() });

            }

            else
            {
                return View();

            }
        }

        // GET: UserAuthentication
        [HttpPost]
        public ActionResult Login(UserAuthentication user)
        {

            
                if (user.UserLogin() > 0)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    Session["username"] = user.Username;

                    return RedirectToAction("Index", "Dashboard");
                }

                else
                {
                    return RedirectToAction("Index","UserAuthentication");
                }
            


           
        }


       

        public ActionResult Logout()

        {


            HttpContext.Session.Clear();
            return RedirectToAction("Login", "UserAuthentication");

        }


           
    }
}