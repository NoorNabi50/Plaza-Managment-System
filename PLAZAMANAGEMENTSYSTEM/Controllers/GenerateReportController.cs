using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{

    [Authorize]
    public class GenerateReportController : Controller
    {
        // GET: GenerateReport
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GenerateReport(Report r)
        {
           
            return View(new PLAZAMANAGEMENTSYSTEM.Models.Report().GenerateReport(r));

        }

    }
}