using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
    [Authorize]
   
    public class DashboardController : Controller
    {









        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "UserAuthentication");

            }

            else
            {
                return View();

            }



            
        }
    }
}