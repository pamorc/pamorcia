using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class Armor
    {
        //[ForeignKey("Player")]
        public int ArmorID { get; set; }

        [MinValue(0, ErrorMessage = "Armor cannot be harmful")]
        public int Head { get; set; }

        [MinValue(0, ErrorMessage = "Armor cannot be harmful")]
        public int Body { get; set; }

        [Display(Name = "Right Arm")]
        [MinValue(0, ErrorMessage = "Armor cannot be harmful")]
        public int RightArm { get; set; }

        [Display(Name = "Left Arm")]
        [MinValue(0, ErrorMessage = "Armor cannot be harmful")]
        public int LeftArm { get; set; }

        [Display(Name = "Right Left")]
        [MinValue(0, ErrorMessage = "Armor cannot be harmful")]
        public int RightLeg { get; set; }

        [Display(Name = "Left Leg")]
        [MinValue(0, ErrorMessage = "Armor cannot be harmful")]
        public int LeftLeg { get; set; }

        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
    }
}
