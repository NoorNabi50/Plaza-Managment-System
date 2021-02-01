using PLAZAMANAGEMENTSYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
   
    [Authorize]
    public class ParkingFloorsController : Controller
    {
        ParkingFloors MyVt = new ParkingFloors();
        // GET: ParkingFloors
        public ActionResult Index()
        {


            return View(MyVt.GetAllParkingFloors());
        }


        public JsonResult List()
        {
            return Json(MyVt.GetAllParkingFloors(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SaveParkingFloors(ParkingFloors Vt)
        {


            if (Vt.SaveParkingFloors() == 1)
            {
                return RedirectToAction("Index", "ParkingFloors");
            }
            string message = "Something went Wrong";
            return View(message);
        }

       
        [HttpPost]

        public JsonResult DeleteParkingFloors(int Id)
        {
            ParkingFloors vt = new ParkingFloors();

            int value = vt.DeleteParkingFloors(Id);
            return Json(value, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]

        public ActionResult UpdateParkingFloor(ParkingFloors Vt)

        {
            if (Vt.UpdateParkingFloor() == 1)
            {
                return RedirectToAction("Index", "ParkingFloors");
            }
            else
            {
                string message = "Something went Wrong";
                return View(message);
            }
        }

        public JsonResult GetParkingFloorById(int Id)

        {
            return Json(new PLAZAMANAGEMENTSYSTEM.Models.ParkingFloors().GetParkingFloorById(Id), JsonRequestBehavior.AllowGet);
        }


        public JsonResult TotalSpaceAvailable()
        {

            ParkingFloors pf = new ParkingFloors();
            int value = pf.TotalSpaceAvailable();
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}