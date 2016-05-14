using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Røde_Kors.Models
{
    public class MyUser: IdentityUser
    {
        [Required]
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int CPR { get; set; }
        public string CO { get; set; }
        public string streetAndNumber { get; set; }
        public int zipcode { get; set; }
        public string city { get; set; }
        public int telefon1 { get; set; }
        public int telefon2 { get; set; }
        public string  email { get; set; }
        public string username { get; set; }
        public string password { get; set; }



        // Look here:  Down low
        // https://blogs.msdn.microsoft.com/webdev/2013/10/16/customizing-profile-information-in-asp-net-identity-in-vs-2013-templates/

    }
}