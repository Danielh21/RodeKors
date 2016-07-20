using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Røde_Kors.Models
{
    public class VagtDag
    {

        public VagtDag(string dag, bool avalible)
        {
            this.avalible = avalible;
            this.dag = dag;
        }

        public VagtDag()
        {

        }
        [Key, Column(Order =0)]
        [ ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order =1)]
        public virtual string dag { get; set; }
        public virtual bool avalible { get; set; }

        // for tomorrow http://stackoverflow.com/questions/21606454/how-to-handle-system-data-entity-validation-dbentityvalidationexception
    }
}