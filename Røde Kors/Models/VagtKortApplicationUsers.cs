using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Røde_Kors.Models
{
    public class VagtKortAndUsers
    {

        public VagtKortAndUsers()
        {

        }
        public VagtKortAndUsers(string ApplicationUserId, int VagtKortId, string Role)
        {
            this.ApplicationUserId = ApplicationUserId;
            this.VagtKortId = VagtKortId;
            this.Role = Role;
            this.Emailed = false;
        }

        public string ApplicationUserId { get; set; }
        public int VagtKortId { get; set; }
        public string Role { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual VagtKort VagtKort { get; set; }

        public bool Emailed { get; set; }

        public bool Chauffør { get; set; }

    }
}