using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{

    [Authorize]
    public class VehicleInfoController : Controller
    {
        // GET: VehicleInfo


        public JsonResult NumberofCarsParked()
        {


          
            try
            {
                VehicleInfo v = new VehicleInfo();
                int value = v.CountVehiclesForDay();


            return Json(value, JsonRequestBehavior.AllowGet);
               
         }

            catch (Exception ex)
            {
                return Json(new { status = "error", message = "error saving info" + ex.Message });
            }

        }

        public JsonResult AmountcollectedForDay()
        {



            try
            {
                VehicleInfo v = new VehicleInfo();
                int value = v.AmountcollectedForDay();
                if (value > 0)
                {

                    return Json(value, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                    ;
                }

            }

            catch (Exception ex)
            {
                return Json(new { status = "error", message = "error saving info" + ex.Message });
            }

        }


        
        public ActionResult SaveVehicleInfo(VehicleInfo VI)
        {


            try
            {
                int value = VI.SaveVehicleInfo();
                if (value > 0)
                {
                    return Json(value,JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return null;
                }
            }

            catch(Exception ex)
            {
                return Json(new { status = "error", message = "error saving info" +ex.Message});
            }

        }


        [HttpGet]

        public ActionResult Index()
        {
            return View(new PLAZAMANAGEMENTSYSTEM.Models.VehicleInfo().GetAllVehicle());
        }

        [HttpGet]
        public ActionResult Receipt(int Id)
        {   
            return View(new PLAZAMANAGEMENTSYSTEM.Models.VehicleInfo().GetVehicleByVehicleNoPlate(Id));
        }
    }
}