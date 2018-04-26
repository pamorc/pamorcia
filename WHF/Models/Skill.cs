using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class Skill
    {
        public int SkillID { get; set; }

        [Display(Name = "Skill")]
        public string Name { get; set; }
        
        public Type SkillType { get; set; }

        public AttributeEnum Attribute { get; set; }

        public string Description { get; set; }
    }

    public enum AttributeEnum
    {
        WeaponSkill,
        BallisticSkill,
        Strength,
        Toughness,
        Agility,
        Intellect,
        Willpower,
        Fellowship
    }

    public enum Type
    {
        Basic,
        Advanced
    }
}
