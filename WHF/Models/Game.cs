using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    public class Game
    {
        public int GameID { get; set; }

        [Display(Name = "Game")]
        public string Name { get; set; }

        public virtual List<Player> Players { get; set; }
    }
}
