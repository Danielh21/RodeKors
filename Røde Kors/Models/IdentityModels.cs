using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Røde_Kors.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public int CPR { get; set; }

        public string CO { get; set; }

        public string streetAndNumber { get; set; }

        public int zipcode { get; set; }

        public string city { get; set; }

        [Required]
        public int telefon1 { get; set; }

        [Required]
        public bool vagtkoordinator {get; set; }

        public bool driver { get; set; }

        public string eduLevel { get; set; }

        public virtual ICollection<VagtDag> VagtDage { get; set; }

        // Dictoinary is not supported by Entity, but we need it
        // for looking up. See method that converts VagtDage to calendar
        [NotMapped]
        public virtual Dictionary<string,bool> calendarDic { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", this.firstName));
            userIdentity.AddClaim(new Claim("LastName", this.lastName));
            userIdentity.AddClaim(new Claim("eduLevel", this.eduLevel));
            return userIdentity;
            }


        // Method that takes the ICollection VagtDage, and converts it to an Dictionary
        // with the prob. dag as Key and the prob. Avalible as Value
        public Dictionary<string, bool> createDictionary()
        {
            if(calendarDic == null)
            {
                calendarDic = new Dictionary<string, bool>();
            }

            foreach(VagtDag dag in VagtDage)
            {
                calendarDic.Add(dag.dag, dag.avalible);
            }

            return calendarDic;

        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Røde_Kors.Models.Rekvirent> Rekvirents { get; set; }

        public System.Data.Entity.DbSet<Røde_Kors.Models.VagtKort> VagtKorts { get; set; }
    }
}