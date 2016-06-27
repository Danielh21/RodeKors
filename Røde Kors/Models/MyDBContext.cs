using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Røde_Kors.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Røde_Kors.Models
{
    public class MyDBContext : IdentityDbContext
    {
        public MyDBContext() : base("Røde Kors")
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<VagtDag> VagtDags { get; set; }

    }
}