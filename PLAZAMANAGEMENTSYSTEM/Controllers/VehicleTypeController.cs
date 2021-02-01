using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
   
    [Authorize]
    public class VehicleTypeController : Controller
    {
        // GET: VehicleType
        public ActionResult Index()
        {
            VehicleType MyVt = new VehicleType();

            return View(MyVt.GetAllVehicleType());
        }

        [HttpPost]
        public ActionResult SaveVehicleType(VehicleType Vt)
        {


            if (Vt.SaveVehicleType() == 1)
            {
                return RedirectToAction("Index", "VehicleType");
            }
            else
            {
                string message = "Something went Wrong";
                return View(message);

            }
        }


        [HttpPost]

        public ActionResult UpdateVehicleType(VehicleType Vt)

        {
            if (Vt.UpdateVehicleType() == 1)
            {
                return RedirectToAction("Index", "VehicleType");
            }
            else
            {
                string message = "Something went Wrong";
                return View(message);
            }
        }


        //[HttpGet]
        //public ActionResult DeleteVehicleType()
        //{
        //    return View();
        //}


        [HttpPost]

        public JsonResult DeleteVehicleType(int Id)
        {
            VehicleType vt = new VehicleType();

            int value = vt.DeleteVehicleType(Id);
            return Json(value, JsonRequestBehavior.AllowGet);

           
        }


        

        public JsonResult GetVehicleTypeById(int Id)

        {
            return Json(new PLAZAMANAGEMENTSYSTEM.Models.VehicleType().GetVehicleTypeById(Id), JsonRequestBehavior.AllowGet);
        }
    }
}