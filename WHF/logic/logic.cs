using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHF.Models;
using System.Web.Mvc;

namespace WHF.logic
{
    public static class logic
    {
        public static void ValidateAttributes(Controller controller, Attributes att)
        {
            // check wound against max wound
            if (att.Wound > att.MaxWound)
            {
                controller.ModelState.AddModelError("Wound", "Wound cannot be higher than Max Wound");
            }

            // check fate point against max fate point
            if (att.FatePoint > att.MaxFatePoint)
            {
                controller.ModelState.AddModelError("FatePoint", "Current Fate Point cannot be higher than Max Fate Point");
            }

            // check fortune against max fate point
            if (att.FortunePoint > att.MaxFatePoint)
            {
                controller.ModelState.AddModelError("FortunePoint", "Fortune cannot be higher than Max Fate Point");
            }
        }

        public static void ValidatePlayer(Controller controller, Player player)
        {
            // check current XP
            if (player.XPCurrent > player.XPTotal)
            {
                controller.ModelState.AddModelError("XPCurrent", "Current XP cannot be higher than total.");
            }
        }

        public static int GetSkillValue(AttributeEnum att, Attributes atts)
        {
            switch (att)
            {
                case AttributeEnum.WeaponSkill:
                    return atts.WeaponSkill;
                case AttributeEnum.BallisticSkill:
                    return atts.BallisticSkill;
                case AttributeEnum.Strength:
                    return atts.Strength;
                case AttributeEnum.Toughness:
                    return atts.Toughness;
                case AttributeEnum.Agility:
                    return atts.Agility;
                case AttributeEnum.Intellect:
                    return atts.Intellect;
                case AttributeEnum.Willpower:
                    return atts.Willpower;
                case AttributeEnum.Fellowship:
                    return atts.Fellowship;
            }
            return 0;
        }
    }
}
