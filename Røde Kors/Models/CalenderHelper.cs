using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Røde_Kors.Models
{

    // This class is a helper class, that handles buissness logic for the calender Controller
    public class CalenderHelper
    {
        // Method for instanciating a new Calender object for a new user.
        // Returns an calender where the users first 50 days are marked as avalible.
        public ICollection<VagtDag> newCalender()
        {
            VagtKalender cal = new VagtKalender();
            ICollection<VagtDag> generatedCalender = new List<VagtDag>();
            for (int i = 0; i < 50; i++)
            {
                string dateTimeString = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                generatedCalender.Add(new VagtDag(dateTimeString, true));
            }
            return generatedCalender;
        }
    }
}