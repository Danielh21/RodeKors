using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Røde_Kors.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace Røde_Kors.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {

        private Helper helper = new Helper();
        private ApplicationUserManager manager;
        private ApplicationUser user;
        private UserStore<ApplicationUser> store;

        private void setUpContext()
        {
            var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            store = new UserStore<ApplicationUser>(dbContext);
            manager = new ApplicationUserManager(store);
            string userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
            user = manager.Users.FirstOrDefault(u => u.Id == userid);
            
        }

        // GET: MyCalendar
        public ActionResult MyCalendar()
        {
            setUpContext();

            if (user.VagtDage.Count == 0)
            {
                // creates an new calender instance if the users calender is null

                user.VagtDage = helper.newCalender();
                manager.Update(user);
            }

            // this instanciate the object Calender which is the Directory used by this controller 
            Session["Calendar"] = user.createDictionary();
            return View();
        }



        /*
        This method is responsable for updating the date that the user
        clicked on, and update it all the way to the database. 
        Also sends an content string back with the color the cell should be after the update.
        */
        [HttpPost]
        public async Task<ActionResult> clcikedcell(string date)
        {


            setUpContext();
            var Calendar = (Dictionary<string, bool>)Session["Calendar"];
            bool availbie = Calendar[date];

            if (availbie)
            {
                // Means that the User whiches to change his/hers 
                // status for that date from Avalible to Not Avalible -> Return Red
                foreach (VagtDag dag in user.VagtDage)
                {
                    if (dag.dag == date)
                    {
                        dag.avalible = false;
                    }
                }
                Calendar[date] = false;
                await manager.UpdateAsync(user);
                Session["Calendar"] = Calendar;
                return Json(false);

            }
            else
            {
                // Means that the User whiches to change his / hers
                // status for that date from not Avalible to Not Avalible -> Return Green

                foreach (VagtDag dag in user.VagtDage)
                {
                    if (dag.dag == date)
                    {
                        dag.avalible = true;
                    }
                }
                Calendar[date] = true;
                await manager.UpdateAsync(user);
                Session["Calendar"] = Calendar;
                return Json(true);
            }
        }


        // Method that is called when the cells are about to be loaded.
        // should look in user.Vagtdag and return true or false based on avalible boolean,
        // for the string comming in. Returns an boolean if the cell should be green or red.
        // Green if avalible is true and red if false.
        [HttpPost]
        public ActionResult loadcell(string date)
        {
                setUpContext();

            try
            {
                var Calendar =(Dictionary< string,bool>) Session["Calendar"];
                bool avalible = Calendar[date];

                if (avalible)
                {
                    // Return Green/ true
                    return Json(true);
                }
                else
                {
                    // Return Red / false
                    return Json(false);
                }
            }
            catch (KeyNotFoundException)
            {
                // means that the user has loaded an date that was not yet in the database!
                user.VagtDage.Add(new VagtDag(date, true));
                var Calendar = (Dictionary<string, bool>)Session["Calendar"];
                Calendar.Add(date, true);
                Session["Calendar"] = Calendar;
                manager.Update(user);
                // since the newly created Date is set as avaible we can just return true 
                return Json(true);
            }
        }
    }
}

// http://stackoverflow.com/questions/14138872/how-to-use-sessions-in-an-asp-net-mvc-4-application