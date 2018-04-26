using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class PlayerTalent
    {
        public int PlayerTalentID { get; set; }

        [Display(Name = "Player")]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        [Display(Name = "Talent")]
        public int TalentID { get; set; }
        public virtual Talent Talent { get; set; }
    }
}
