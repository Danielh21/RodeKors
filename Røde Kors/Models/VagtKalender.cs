using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Røde_Kors.Models
{
    public class VagtKalender
    {
        public int kalenderid { get; set; }

        public Dictionary<String, bool> kalender {get; set;}
    }

}