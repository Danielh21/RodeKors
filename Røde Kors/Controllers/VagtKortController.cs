using Røde_Kors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Røde_Kors.Controllers
{
    public class VagtKortController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: VagtKort
        public ActionResult Index()
        {
            return View();
        }

        // GET: Create Rekvirant
        public ActionResult CreateRekvirant()
        {
            return View();
        }

        //GET: Rekvirant List
        public ActionResult ListOfRekvirant()
        {
           List<Rekvirent> list =  context.Rekvirents.ToList();

            return View(list);
        }

        //POST Create Rekvirant
       [HttpPost]
        public  ActionResult CreateRekvirant(Rekvirent model)
        {
            if (ModelState.IsValid)
            {

               context.Rekvirents.Add(model);
               context.SaveChanges();

            }

            return RedirectToAction("ListOfRekvirant", "VagtKort");

        }


        //GET
        // Nyt Vagtkort

        public ActionResult NewVagtkortStart()
        {
            if(Session["VagtKort"] != null)
            {
                VagtKort kort = (VagtKort) Session["VagtKort"];
                return View(kort);
            }

            else

            return View();
        }

        /*
        POST:
        Method for finding the selcted Rekvirent,
        and Returning it as a Json!
        */
        [HttpPost]
       public ActionResult findRekvirent(int id)
        {
            var hash = context.Rekvirents.ToDictionary(t => t.revkirentId);
            Rekvirent re = hash[id];
            var json =  new JavaScriptSerializer().Serialize(re);
            return Json(json);

        }

        // POST: Method for handling post Request from the view. 
        [HttpPost]
        public ActionResult NewVagtKortStart(VagtKort model)
        {

            // Make sure that the fields are filled by the user!
            if ( model.VagtNavn == null ||
                model.VagtStart == null ||
                model.ArregmenetSlut == null ||
                model.VagtSted == null ||
                model.RekvirentKontaktPerson == null ||
                model.RekvirentKontaktPersonDetajler == null ||
                model.VagtAdresse == null ||
                model.VagtPostnumberBy == null ||
                model.Rekvirent_RekvirentId == 0
                )
            {
                return View(model);
            }
            
            // Find the Rekvirent and saves it as an object under vagtkort
            // Not saved in the database!
            var hash = context.Rekvirents.ToDictionary(t => t.revkirentId);
            Rekvirent rekvirent = hash[model.Rekvirent_RekvirentId];
            model.Rekvirent = rekvirent;

            Session["VagtKort"] = model;
            return RedirectToAction("NewVagtKortDetaljer", "Vagtkort");
        }

        // GET: Method for showing second Screen in create vagtkort

        public ActionResult NewVagtKortDetaljer()
        {
            if (Session["VagtKort"] == null)
            {
                return RedirectToAction("NewVagtkortStart", "Vagtkort");
            }
            VagtKort model = (VagtKort)Session["VagtKort"];
            return View(model);
        }

        //POST:
        // Method for loading the Rekvirent for Vagtkort and sending back a JSON object!
        public ActionResult ajaxRekvirentStandard()
        {
            VagtKort currentVagtKort = (VagtKort) Session["VagtKort"];
            Rekvirent currentRekivirent = currentVagtKort.Rekvirent;
            var jsonObj = new JavaScriptSerializer().Serialize(currentRekivirent);
            return Json(jsonObj);

        }

        // POST: For handling the Details of the VagtKort
        [HttpPost]
        public ActionResult NewVagtKortDetaljer(VagtKort model)
        {
            if(model.Kommentar == null ||
                model.Forplejning == null ||
                model.RødeKorsMaterialer == null ||
                model.RekvirentMaterialer == null)
            {
                return View(model);
            }

            else
            {
                VagtKort vagtkort = (VagtKort) Session["VagtKort"];
                vagtkort.Kommentar = model.Kommentar;
                vagtkort.Forplejning = model.Forplejning;
                vagtkort.RødeKorsMaterialer = model.RødeKorsMaterialer;
                vagtkort.RekvirentMaterialer = model.RekvirentMaterialer;
                vagtkort.AntalVagtleder = model.AntalVagtleder;
                vagtkort.AntalMedics = model.AntalMedics;
                vagtkort.AntalTeamLeder = model.AntalTeamLeder;
                vagtkort.AntalTeamSamarit = model.AntalTeamSamarit;
                vagtkort.AntalElev = model.AntalElev;
                vagtkort.AntalObs = model.AntalObs;
                Session["VagtKort"] = vagtkort;
                return RedirectToAction("ConfirmVagtkort", "VagtKort");
            }
        }

            //GET: Confirm VagtKort

            public ActionResult ConfirmVagtkort()
        {
            var vagtkort = Session["Vagtkort"];
            return View(vagtkort);
        }



        //GET: Returns an list of VagtKort where the end date has not yet been reached.
        public ActionResult UpcommingVagtKorts()
        {
            List<VagtKort> listofVagtkort = context.VagtKorts.ToList<VagtKort>();
            List<VagtKort> Upcomming = new List<VagtKort>();

            foreach (VagtKort vagtKort in listofVagtkort)
            {
                DateTime now = DateTime.Now;

                if (vagtKort.VagtSlut > now)
                {
                    Upcomming.Add(vagtKort);
                }
            }

            return View(Upcomming);
        }

        //POST:
        // Saves the VagtKort when the user has confirmed it!
        public ActionResult CreateVagtKort()
        {
            VagtKort vagtkort = (VagtKort) Session["Vagtkort"];
            // Saves the Rekvirent again, and that needs to change!
            context.Entry(vagtkort.Rekvirent).State = EntityState.Detached;
            vagtkort = context.VagtKorts.Add(vagtkort);
            context.SaveChanges();

            Session["Vagtkort"] = null; // Clears the session Vagtkort after the save.
            // Here!!!! Must return too assigning the ApplicationUsers!

            return RedirectToAction("AssignUsers","VagtKort", new { id = vagtkort.VagtKortId });
        }

        // GET:
        // Assign Users to Vagten.
        // At this point the Vagtkort has been created an assigned an ID in the database!
        public ActionResult AssignUsers(int id)
        {
            //VagtKort vagtkort = context.VagtKorts.Find(id);
            //List<ApplicationUser> list = context.Users.ToList<ApplicationUser>();
            //ApplicationUser user = list[0];
            //context.SaveChanges();
            //return View(vagtkort);
        }

    }

}