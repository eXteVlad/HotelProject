using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        HotelDB db = new HotelDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reservation()
        {
            if (Session["UserID"] == null) return RedirectToAction("Login", "Account");

            IEnumerable<ROOMS> a = db.ROOMS;
            ViewBag.Rooms = a;
            return View();
        }

        [HttpPost]
        public ActionResult Reservation(RoomInfo rooms)
        {
            if (Session["UserID"] == null) return RedirectToAction("Login", "Account");

            var room = db.ROOMS.Where(m => m.CATEGORY == rooms.catRoom && m.PLACES == rooms.placeRoom).First();

            if (room == null)
            {
                ViewBag.Error = "В данный момент нет свободных номеров по Вашему запросу.";
                return View();
            }

            List<RESERVATION> addRoom = new List<RESERVATION>();

            int id = Int32.Parse(Session["UserID"].ToString());

            addRoom.Add(new RESERVATION() { ID_CLIENT = id, ID_ROOM = room.ID_ROOM, DATE_IN = rooms.dateinRoom, DATE_OUT = rooms.dateoutRoom });

            foreach(var i in addRoom)
            {
                db.RESERVATION.Add(i);
            }
            db.SaveChanges();
            ViewBag.SuccessReserv = "Вы успешно забронировали номер.";
            RedirectToAction("Profile", "Account");
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Services()
        {
            if (Session["UserID"] == null) return RedirectToAction("Login", "Account");

            IEnumerable<SERVICES> a = db.SERVICES;
            ViewBag.Services = a;
            return View();
        }
    }
}