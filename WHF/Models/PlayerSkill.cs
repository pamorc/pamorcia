using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class PlayerSkill
    {
        public int PlayerSkillID { get; set; }

        [Display(Name = "Player")]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        [Display(Name = "Skill")]
        public int SkillID { get; set; }
        public virtual Skill Skill { get; set; }

        public virtual AttributeEnum Attribute { get; set; }

        [Display(Name = "Skill value")]
        public virtual int SkillValue { get; set; }
    }
}
