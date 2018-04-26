using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class Carrier
    {
        public int CarrierID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public Type CarrierType { get; set; }

        public string Description { get; set; }

        public virtual List<Carrier> Entries { get; set; }

        public virtual List<Carrier> Exits { get; set; }

        public int AdvWS { get; set; }

        public int AdvBS { get; set; }

        public int AdvS { get; set; }

        public int AdvT { get; set; }

        public int AdvA { get; set; }

        public int AdvI { get; set; }

        public int AdvWP { get; set; }

        public int AdvFS { get; set; }

        public int AdvWound { get; set; }

        public int AdvAttack { get; set; }

        public int AdvMove { get; set; }

        public int AdvMagic { get; set; }
    }
}
