using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        public string Name { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }

        public int AttributesID { get; set; }
        public Attributes Attributes { get; set; }

        public int ArmorID { get; set; }
        public Armor Armor { get; set; }

        [Display(Name = "Total XP")]
        public int XPTotal { get; set; }

        [Display(Name = "Current XP")]
        public int XPCurrent { get; set; }

        public virtual List<PlayerSkill> Skills { get; set; }

        public virtual List<PlayerTalent> Talents { get; set; }

        [NotMapped]
        public virtual Attack attack { get; set; }
    }

    [NotMapped]
    public class Attack
    {
        public int PlayerID { get; set; }

        public int Roll { get; set; }

        public int Damage { get; set; }
        
    }
}
