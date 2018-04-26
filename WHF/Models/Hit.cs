using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    [NotMapped]
    public class Hit
    {
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        //[UIHint("Editor")]
        int _roll;
        public int Roll
        {
            get { return _roll; }
            set
            {
                if (value >= 1 && value <= 15) { Location = "Head"; }
                else if (value >= 16 && value <= 35) { Location = "Right Arm"; }
                else if (value >= 36 && value <= 55) { Location = "Left Arm"; }
                else if (value >= 56 && value <= 80) { Location = "Body"; }
                else if (value >= 81 && value <= 90) { Location = "Right Leg"; }
                else if (value >= 91 && value <= 100) { Location = "Left Leg"; }
                _roll = value;
            }
        }

        //[UIHint("Editor")]
        public int Damage { get; set; }

        string _location
        {
            get
            {
                if (Roll >= 1 && Roll <= 15) { return "Head"; }
                else if (Roll >= 16 && Roll <= 35) { return "Right Arm"; }
                else if (Roll >= 36 && Roll <= 55) { return "Left Arm"; }
                else if (Roll >= 56 && Roll <= 80) { return "Body"; }
                else if (Roll >= 81 && Roll <= 90) { return "Right Leg"; }
                else if (Roll >= 91 && Roll <= 100) { return "Left Leg"; }
                return "no location";
            }
            set
            {
                _location = value;
            }
        }
        public string Location { get; set; }

        [Display(Name = "Direct Damage")]
        public int DirectDmg { get; set; }

        [Display(Name = "Armour Piercing")]
        public bool ArmourPiercing { get; set; }

        [Display(Name = "Sure Shot")]
        public bool SureShot { get; set; }
    }
}
