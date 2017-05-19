using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        HotelDB db = new HotelDB();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CLIENTS account)
        {
            if(ModelState.IsValid)
            {
                var acc = db.CLIENTS.SingleOrDefault(u => u.LOGIN == account.LOGIN);
                if(acc != null)
                {
                    ModelState.AddModelError("LOGIN", "Такой логин уже занят.");
                    return View();
                }
                if(account.GENDER != "Мужской" && account.GENDER != "Женский")
                {
                    ModelState.AddModelError("GENDER", "Введите 'Мужской' или 'Женский'.");
                    return View();
                }
                db.CLIENTS.Add(account);
                db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = account.IM + " " + account.OT + ", " + "вы успешно зарегистрировались!";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CLIENTS user)
        {
            var acc = db.CLIENTS.Single(u => u.LOGIN == user.LOGIN && u.PASSWORD == user.PASSWORD);
            if(acc != null)
            {
                Session["UserID"] = acc.ID_CLIENT.ToString();
                Session["UserLogin"] = acc.LOGIN.ToString();
                Session["UserName"] = acc.IM.ToString();
                Session["UserOt"] = acc.OT.ToString();
                return RedirectToAction("Profile");
            }
            else
            {
                ModelState.AddModelError("", "Логин или пароль введён неверно.");
            }
            return View();
        }
        public new ActionResult Profile()
        {
            if (Session["UserID"] == null) return RedirectToAction("Login");

            int id = Int32.Parse(Session["UserID"].ToString());
            var room = db.RESERVATION.Where(n => n.ID_CLIENT == id).Join(db.ROOMS, p => p.ID_ROOM, n => n.ID_ROOM, (p, n) => new
            {
                num_r = n.NUM_ROOM,
                place_r = n.PLACES,
                price_r = n.PRICE,
                datein_r = p.DATE_IN,
                dateout_r = p.DATE_OUT
            });

            //foreach(var i in room)
            //{
            //    ri.idClient = id;
            //    ri.numRoom = (int)i.num_r;
            //    ri.placeRoom = (int)i.place_r;
            //    ri.priceRoom = (int)i.price_r;
            //    ri.dateinRoom = (DateTime)i.datein_r;
            //    ri.dateoutRoom = (DateTime)i.dateout_r;
            //}
            List<CLIENTS> clients = db.CLIENTS.Where(n => n.ID_CLIENT == id).ToList();
            //доделать 
            //есть модель RoomInfo, данные о клиенете передаются через ViewBag, данные о номере передаются через модель RoomInfo
            ViewBag.Client = clients;

            return View();
        }

        [HttpPost]
        public ActionResult Exit()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ProfileEdit()
        {
            if (Session["UserID"] == null) return RedirectToAction("Login");
            return View();
        }
        [HttpPost]
        public ActionResult ProfileEdit(CLIENTS data)
        {
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewBag.Message = "Вы успешно изменили свои данные.";
            return View();
        }
    }
}