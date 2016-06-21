using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Røde_Kors.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Røde_Kors.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyCalendar
        public ActionResult MyCalendar()
        {
            return View();
        }


        /*
        This method is responsable for updating the date that the user
        clicked on, and update it all the way to the database. 
        Also sends an content string back with the color the cell should be after the update.
        */
        [HttpPost]
        public ActionResult testing(string date)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            

            return Content("red");
        }

        [HttpPost]
        public ActionResult Avalibilty(string date)
        {
            if (date == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}