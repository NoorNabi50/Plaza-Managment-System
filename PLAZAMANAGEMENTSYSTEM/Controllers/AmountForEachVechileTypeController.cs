using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
    
    [Authorize]
    public class AmountForEachVechileTypeController : Controller
    {
        // GET: AmountForEachVechileType
        public ActionResult Index()
        { 
            AmountForEachVechileType avt = new AmountForEachVechileType();
            return View(avt.GetAllAmountForEachVechileType());
        }


        public ActionResult SaveAmountForEachVechileType(AmountForEachVechileType Av)
        {
            if(Av.SaveAmountForEachVehicleType() == 1)
            {

                return RedirectToAction("Index", "AmountForEachVechileType");

            }

            else
            {
                string message = "Something went wrong";
                return View(message);

            }

        }


        public JsonResult GetAmountByVehicleType(int Id)
        {
            AmountForEachVechileType Av = new AmountForEachVechileType();
            int amount = Av.GetAmountByVehicleType(Id);
            return Json(amount, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]

        public JsonResult DeleteAmountForEachVechileType(int Id)
        {
           AmountForEachVechileType vt = new AmountForEachVechileType();

            int value = vt.DeleteAmountForEachVechileType(Id);
            return Json(value, JsonRequestBehavior.AllowGet);


        }

        public JsonResult AmountForEachVechileTypeById(int Id)

        {
            return Json(new PLAZAMANAGEMENTSYSTEM.Models.AmountForEachVechileType().GetAmountForEachVehicleTypeById(Id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateAmountForEachVechileType(AmountForEachVechileType Vt)

        {
            if (Vt.UpdateAmountForEachVechileType() == 1)
            {
                return RedirectToAction("Index", "AmountForEachVechileType");
            }
            else
            {
                string message = "Something went Wrong";
                return View(message);
            }
        }
    }
}