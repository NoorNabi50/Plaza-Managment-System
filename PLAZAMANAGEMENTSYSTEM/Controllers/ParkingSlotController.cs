using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
    [Authorize]
    public class ParkingSlotController : Controller
    {
        // GET: ParkingSlot
        public ActionResult Index()
        {
            ParkingSlot Ps = new ParkingSlot();


            return View(Ps.GetAllParkingSlot());
        }

        [HttpPost]

        public ActionResult UpdateParkingSlot(ParkingSlot Vt)

        {
            if (Vt.UpdateParkingSlot() == 1)
            {
                return RedirectToAction("Index", "ParkingSlot");
            }
            else
            {
                string message = "Something went Wrong";
                return View(message);
            }
        }

        public JsonResult GetParkingSlotById(int Id)

        {
            return Json(new PLAZAMANAGEMENTSYSTEM.Models.ParkingSlot().GetParkingSlotById(Id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveParkingSlot(ParkingSlot Ps)
        {
            if(Ps.SaveParkingSlot()==1)
            {
                return RedirectToAction("Index", "ParkingSlot");


            }

            else
            {
                string message = "Something went Wrong";
                return View(message);
            }

        }



        [HttpPost]

        public JsonResult DeleteParkingSlot(int Id)
        {
            ParkingSlot vt = new ParkingSlot();

            int value = vt.DeleteParkingSlot(Id);
            return Json(value, JsonRequestBehavior.AllowGet);


        }

        
        public JsonResult GetFloorNameBySlotId(int Id)
        {

              return Json(new PLAZAMANAGEMENTSYSTEM.Models.ParkingSlot().GetFloorNameBySlotId(Id), JsonRequestBehavior.AllowGet);
        }
    }
}