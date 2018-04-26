using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public enum DisplayType
    {
        Long,
        Short
    }

    public class Attributes
    {
        [NotMapped]
        public DisplayType display = DisplayType.Long;

        //[ForeignKey("Player")]
        public int AttributesID { get; set; }

        public int WeaponSkill { get; set; }

        public int BallisticSkill { get; set; }

        public int Strength { get; set; }

        public int Toughness { get; set; }

        public int Agility { get; set; }

        public int Intellect { get; set; }

        public int Willpower { get; set; }

        public int Fellowship { get; set; }


        public string MeleeDamage { get; set; }

        public string RangedDamage { get; set; }


        public int MaxWound { get; set; }

        [MinValue(-10, ErrorMessage = "Player is really dead now.")]
        public int Wound { get; set; }

        public int Attack { get; set; }

        public int Move { get; set; }

        public int Magic { get; set; }

        public int MaxFatePoint { get; set; }

        [MinValue(0, ErrorMessage = "No more fate points to spend")]
        public int FatePoint { get; set; }

        [MinValue(0, ErrorMessage = "No more fortune points to spend.")]
        public int FortunePoint { get; set; }

        [MinValue(0, ErrorMessage = "You cannot be saner than that.")]
        [MaxValue(100, ErrorMessage = "There is no way to be more insane than you currently are.")]
        public int Insanity { get; set; }


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


        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        [NotMapped]
        public string WSName { get { if (display == DisplayType.Long) { return "Weapon Skill"; } else { return "WS"; } } }

        [NotMapped]
        public string BSName { get { if (display == DisplayType.Long) { return "Ballistic Skill"; } else { return "BS"; } } }

        [NotMapped]
        public string SName { get { if (display == DisplayType.Long) { return "Strength"; } else { return "S"; } } }

        [NotMapped]
        public string TName { get { if (display == DisplayType.Long) { return "Toughness"; } else { return "T"; } } }

        [NotMapped]
        public string AName { get { if (display == DisplayType.Long) { return "Agility"; } else { return "A"; } } }

        [NotMapped]
        public string IName { get { if (display == DisplayType.Long) { return "Intelligence"; } else { return "I"; } } }

        [NotMapped]
        public string WPName { get { if (display == DisplayType.Long) { return "Willpower"; } else { return "WP"; } } }

        [NotMapped]
        public string FSName { get { if (display == DisplayType.Long) { return "Fellowship"; } else { return "FS"; } } }

        [NotMapped]
        public string MDmgName { get { if (display == DisplayType.Long) { return "Melee Damage"; } else { return "MDmg"; } } }

        [NotMapped]
        public string RDmgName { get { if (display == DisplayType.Long) { return "Ranged Damage"; } else { return "RDmg"; } } }

        [NotMapped]
        public string MaxWoundName { get { if (display == DisplayType.Long) { return "Maximum Wound"; } else { return "Max Wound"; } } }

        [NotMapped]
        public string WoundName { get { if (display == DisplayType.Long) { return "Current Wound"; } else { return "Wound"; } } }

        [NotMapped]
        public string AttackName { get { if (display == DisplayType.Long) { return "Attack"; } else { return "Attack"; } } }

        [NotMapped]
        public string MoveName { get { if (display == DisplayType.Long) { return "Move"; } else { return "Move"; } } }

        [NotMapped]
        public string MagicName { get { if (display == DisplayType.Long) { return "Magic"; } else { return "Magic"; } } }

        [NotMapped]
        public string FateName { get { if (display == DisplayType.Long) { return "Current Fate Point"; } else { return "Fate"; } } }

        [NotMapped]
        public string MaxFateName { get { if (display == DisplayType.Long) { return "Maximum Fate Point"; } else { return "Max Fate"; } } }

        [NotMapped]
        public string FortuneName { get { if (display == DisplayType.Long) { return "Fortune Point"; } else { return "Fortune"; } } }

        [NotMapped]
        public string InsanityName { get { if (display == DisplayType.Long) { return "Insanity"; } else { return "Insanity"; } } }
    }

    public class MaxValueAttribute : ValidationAttribute
    {
        private readonly int _maxValue;

        public MaxValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (int)value <= _maxValue;
        }
    }

    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            return (int)value >= _minValue;
        }
    }
}
