using Røde_Kors.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult NewVagtKortStart(VagtKort kort)
        {

           return RedirectToAction("NewVagtKort2", "Vagtkort");
        }

        // GET: Method for showing second Screen in create vagtkort

        public ActionResult NewVagtKort2()
        {
            return View();
        }
    }
}