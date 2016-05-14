using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Røde_Kors.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("Vagtmanager")
        {

        }


    }
}