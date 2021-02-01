using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
    [Authorize]
    public class ReportTypeController : Controller
    {
        // GET: ReportType
        public ActionResult Index()
        {
            ReportType type = new ReportType();


            return View(type.GetAllReportType());
        }


        [HttpPost]
        public ActionResult SaveReportType(ReportType Vt)
        {


            if (Vt.SaveReportType() == 1)
            {
                return RedirectToAction("Index", "ReportType");
            }
            else
            {
                string message = "Something went Wrong";
                return View(message);

            }

        }


        public JsonResult GetReportTypeById(int Id)

        {
            return Json(new PLAZAMANAGEMENTSYSTEM.Models.ReportType().GetReportTypeById(Id), JsonRequestBehavior.AllowGet);
        }
    }
}