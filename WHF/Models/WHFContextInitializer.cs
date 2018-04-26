using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHF.Models
{
    class WHFContextInitializer : DropCreateDatabaseAlways<WHFContext>
    {

        protected override void Seed(WHFContext context)
        {
            Game game = context.Games.Add(new Game()
            {
                Name = "WHF1"
            });
            context.SaveChanges();

            addCharacters(context, game);
            context.SaveChanges();
            connectPlayerAttributesArmor(context);

            loadSkills(context);

            context.SaveChanges();
        }

        private void addCharacters(WHFContext context, Game game)
        {
            context.Players.Add(new Player()
            {
                Name = "Ingrid",
                GameID = game.GameID,
                XPTotal = 765,
                XPCurrent = 165,
                Attributes = context.Attributes.Add(new Attributes()
                {
                    WeaponSkill = 41,
                    BallisticSkill = 24,
                    Strength = 38,
                    Toughness = 33,
                    Agility = 36,
                    Intellect = 35,
                    Willpower = 29,
                    Fellowship = 26,

                    MeleeDamage = "D10+3",
                    RangedDamage = "-",

                    MaxWound = 13,
                    Wound = 13,
                    Attack = 1,
                    Move = 4,
                    Magic = 0,
                    MaxFatePoint = 3,
                    FatePoint = 3,
                    FortunePoint = 3,
                    Insanity = 8,

                    AdvWS = 10,
                    AdvBS = 0,
                    AdvS = 5,
                    AdvT = 0,
                    AdvA = 10,
                    AdvI = 5,
                    AdvWP = 0,
                    AdvFS = 0,
                    AdvAttack = 0,
                    AdvWound = 1,
                    AdvMove = 0,
                    AdvMagic = 0
                }),
                Armor = context.Armors.Add(new Armor()
                {
                    Head = 0,
                    Body = 1,
                    LeftArm = 0,
                    RightArm = 0,
                    LeftLeg = 0,
                    RightLeg = 0
                })
            });
            context.Players.Add(new Player()
            {
                Name = "Dwarek",
                GameID = game.GameID,
                XPTotal = 740,
                XPCurrent = 240,
                Attributes = context.Attributes.Add(new Attributes()
                {
                    WeaponSkill = 48,
                    BallisticSkill = 27,
                    Strength = 31,
                    Toughness = 42,
                    Agility = 25,
                    Intellect = 36,
                    Willpower = 33,
                    Fellowship = 26,

                    MeleeDamage = "D10+3",
                    RangedDamage = "-",

                    MaxWound = 15,
                    Wound = 15,
                    Attack = 1,
                    Move = 3,
                    Magic = 1,
                    MaxFatePoint = 3,
                    FatePoint = 3,
                    FortunePoint = 3,
                    Insanity = 5,

                    AdvWS = 5,
                    AdvBS = 0,
                    AdvS = 5,
                    AdvT = 0,
                    AdvA = 0,
                    AdvI = 5,
                    AdvWP = 0,
                    AdvFS = 0,
                    AdvAttack = 0,
                    AdvWound = 2,
                    AdvMove = 0,
                    AdvMagic = 1
                }),
                Armor = context.Armors.Add(new Armor()
                {
                    Head = 0,
                    Body = 3,
                    LeftArm = 2,
                    RightArm = 0,
                    LeftLeg = 0,
                    RightLeg = 0
                })
            });
            context.Players.Add(new Player()
            {
                Name = "Giovanni",
                GameID = game.GameID,
                XPTotal = 740,
                XPCurrent = 240,
                Attributes = context.Attributes.Add(new Attributes()
                {
                    WeaponSkill = 40,
                    BallisticSkill = 40,
                    Strength = 33,
                    Toughness = 39,
                    Agility = 39,
                    Intellect = 31,
                    Willpower = 31,
                    Fellowship = 41,

                    MeleeDamage = "D10+3",
                    RangedDamage = "D10+3",

                    MaxWound = 12,
                    Wound = 12,
                    Attack = 1,
                    Move = 4,
                    Magic = 0,
                    MaxFatePoint = 2,
                    FatePoint = 2,
                    FortunePoint = 2,
                    Insanity = 6,

                    AdvWS = 5,
                    AdvBS = 5,
                    AdvS = 0,
                    AdvT = 0,
                    AdvA = 5,
                    AdvI = 0,
                    AdvWP = 0,
                    AdvFS = 10,
                    AdvAttack = 0,
                    AdvWound = 0,
                    AdvMove = 0,
                    AdvMagic = 0
                }),
                Armor = context.Armors.Add(new Armor()
                {
                    Head = 0,
                    Body = 0,
                    LeftArm = 0,
                    RightArm = 0,
                    LeftLeg = 0,
                    RightLeg = 0
                })
            });
            context.Players.Add(new Player()
            {
                Name = "Gunther",
                GameID = game.GameID,
                XPTotal = 740,
                XPCurrent = 240,
                Attributes = context.Attributes.Add(new Attributes()
                {
                    WeaponSkill = 50,
                    BallisticSkill = 27,
                    Strength = 42,
                    Toughness = 31,
                    Agility = 30,
                    Intellect = 40,
                    Willpower = 27,
                    Fellowship = 32,

                    MeleeDamage = "D10+3",
                    RangedDamage = "D10",

                    MaxWound = 13,
                    Wound = 13,
                    Attack = 2,
                    Move = 5,
                    Magic = 0,
                    MaxFatePoint = 3,
                    FatePoint = 2,
                    FortunePoint = 3,
                    Insanity = 8,

                    AdvWS = 10,
                    AdvBS = 0,
                    AdvS = 5,
                    AdvT = 0,
                    AdvA = 0,
                    AdvI = 0,
                    AdvWP = 0,
                    AdvFS = 0,
                    AdvAttack = 1,
                    AdvWound = 2,
                    AdvMove = 0,
                    AdvMagic = 0
                }),
                Armor = context.Armors.Add(new Armor()
                {
                    Head = 0,
                    Body = 1,
                    LeftArm = 0,
                    RightArm = 0,
                    LeftLeg = 0,
                    RightLeg = 0
                })
            });
            context.Players.Add(new Player()
            {
                Name = "Hargin",
                GameID = game.GameID,
                XPTotal = 740,
                XPCurrent = 240,
                Attributes = context.Attributes.Add(new Attributes()
                {
                    WeaponSkill = 53,
                    BallisticSkill = 34,
                    Strength = 37,
                    Toughness = 41,
                    Agility = 28,
                    Intellect = 30,
                    Willpower = 36,
                    Fellowship = 18,

                    MeleeDamage = "D10+3",
                    RangedDamage = "-",

                    MaxWound = 12,
                    Wound = 12,
                    Attack = 2,
                    Move = 3,
                    Magic = 0,
                    MaxFatePoint = 2,
                    FatePoint = 2,
                    FortunePoint = 2,
                    Insanity = 6,

                    AdvWS = 10,
                    AdvBS = 0,
                    AdvS = 5,
                    AdvT = 5,
                    AdvA = 0,
                    AdvI = 0,
                    AdvWP = 0,
                    AdvFS = 0,
                    AdvAttack = 1,
                    AdvWound = 1,
                    AdvMove = 0,
                    AdvMagic = 0
                }),
                Armor = context.Armors.Add(new Armor()
                {
                    Head = 1,
                    Body = 3,
                    LeftArm = 0,
                    RightArm = 0,
                    LeftLeg = 0,
                    RightLeg = 0
                })
            });
            context.Players.Add(new Player()
            {
                Name = "Konrad",
                GameID = game.GameID,
                XPTotal = 690,
                XPCurrent = 190,
                Attributes = context.Attributes.Add(new Attributes()
                {
                    WeaponSkill = 39,
                    BallisticSkill = 38,
                    Strength = 34,
                    Toughness = 31,
                    Agility = 29,
                    Intellect = 44,
                    Willpower = 34,
                    Fellowship = 43,

                    MeleeDamage = "D10+2",
                    RangedDamage = "-",

                    MaxWound = 13,
                    Wound = 13,
                    Attack = 1,
                    Move = 4,
                    Magic = 0,
                    MaxFatePoint = 3,
                    FatePoint = 3,
                    FortunePoint = 3,
                    Insanity = 5,

                    AdvWS = 5,
                    AdvBS = 0,
                    AdvS = 5,
                    AdvT = 0,
                    AdvA = 0,
                    AdvI = 5,
                    AdvWP = 0,
                    AdvFS = 10,
                    AdvAttack = 0,
                    AdvWound = 1,
                    AdvMove = 0,
                    AdvMagic = 0
                }),
                Armor = context.Armors.Add(new Armor()
                {
                    Head = 0,
                    Body = 1,
                    LeftArm = 0,
                    RightArm = 0,
                    LeftLeg = 0,
                    RightLeg = 0
                })
            });
        }

        private void connectPlayerAttributesArmor(WHFContext context)
        {
            Player player = context.Players.Single(p => p.Name == "Ingrid");
            Attributes att = context.Attributes.Single(a => a.Player.Name == player.Name);
            Armor armor = context.Armors.Single(a => a.Player.Name == player.Name);

            player.AttributesID = att.AttributesID;
            player.ArmorID = armor.ArmorID;
            att.PlayerID = player.PlayerID;
            armor.PlayerID = player.PlayerID;

            player = context.Players.Single(p => p.Name == "Dwarek");
            att = context.Attributes.Single(a => a.Player.Name == player.Name);
            armor = context.Armors.Single(a => a.Player.Name == player.Name);

            player.AttributesID = att.AttributesID;
            player.ArmorID = armor.ArmorID;
            att.PlayerID = player.PlayerID;
            armor.PlayerID = player.PlayerID;

            player = context.Players.Single(p => p.Name == "Giovanni");
            att = context.Attributes.Single(a => a.Player.Name == player.Name);
            armor = context.Armors.Single(a => a.Player.Name == player.Name);

            player.AttributesID = att.AttributesID;
            player.ArmorID = armor.ArmorID;
            att.PlayerID = player.PlayerID;
            armor.PlayerID = player.PlayerID;

            player = context.Players.Single(p => p.Name == "Gunther");
            att = context.Attributes.Single(a => a.Player.Name == player.Name);
            armor = context.Armors.Single(a => a.Player.Name == player.Name);

            player.AttributesID = att.AttributesID;
            player.ArmorID = armor.ArmorID;
            att.PlayerID = player.PlayerID;
            armor.PlayerID = player.PlayerID;

            player = context.Players.Single(p => p.Name == "Hargin");
            att = context.Attributes.Single(a => a.Player.Name == player.Name);
            armor = context.Armors.Single(a => a.Player.Name == player.Name);

            player.AttributesID = att.AttributesID;
            player.ArmorID = armor.ArmorID;
            att.PlayerID = player.PlayerID;
            armor.PlayerID = player.PlayerID;

            player = context.Players.Single(p => p.Name == "Konrad");
            att = context.Attributes.Single(a => a.Player.Name == player.Name);
            armor = context.Armors.Single(a => a.Player.Name == player.Name);

            player.AttributesID = att.AttributesID;
            player.ArmorID = armor.ArmorID;
            att.PlayerID = player.PlayerID;
            armor.PlayerID = player.PlayerID;
        }

        private void loadSkills(WHFContext context)
        {
            context.Skills.Add(new Skill()
            {
                Name = "Academic Knowledge: null",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = "Use Academic Knowledge to remember pertinent facts and figures, and (if you have access to the proper facilities of resources) do research. Academic Knowledge represents a peth of learning far beyond Common Knowledge and requires extensive study."
            });
            context.Skills.Add(new Skill()
            {
                Name = "Animal Care",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Intellect,
                Description = "Use this skill to take care of farm and domestic animals, like horses, cattle, pigs, oxen and the like. Routine care and feeding require no Skill Test. Tests are most commonly made to spot developing illnesses or signs of discomfort, or for special grooming (preparing a mount for a parade, for instance)."
            });
            context.Skills.Add(new Skill()
            {
                Name = "Animal Training",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Blather",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Channeling",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Willpower,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Charm",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Charm Animal",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Command",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Common Knowledge",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Concealment",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Consume Alcohol",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Toughness,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Disguise",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Dodge Blow",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Drive",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Strength,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Evaluate",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Follow Trail",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Gamble",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Gossip",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Haggle",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Heal",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Hypnotism",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Willpower,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Intimidate",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Strength,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Lip Reading",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Magical Sense",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Willpower,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Navigation",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Outdoor Survival",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Perception",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Performer",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Pick Lock",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Prepare Poison",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Read/Write",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Ride",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Row",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Strength,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Sail",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Scale Sheer Surface",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Strength,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Search",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Secret Language",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Secret Signs",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Set Trap",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Silent Move",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Shadowing",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Sleight of Hand",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Agility,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Speak Arvcane Language",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Speak Language",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Swim",
                SkillType = Type.Basic,
                Attribute = AttributeEnum.Strength,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Torture",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Trade",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Intellect,
                Description = ""
            });
            context.Skills.Add(new Skill()
            {
                Name = "Ventriloquism",
                SkillType = Type.Advanced,
                Attribute = AttributeEnum.Fellowship,
                Description = ""
            });

            context.Talents.Add(new Talent()
            {
                Name = "Acute Hearing",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Aethyric Attunement",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Alley Cat",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Ambidextrous",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Arcane Lore",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Armoured Casting",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Artistic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Contortionist",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Coolheaded",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Dark Lore",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Dark Magic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Dealmaker",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Disarm",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Divine Lore",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Dwarfcraft",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Etiquette",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Excellent Vision",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Fast Hands",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Fearless",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Flee!",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Fleet Footed",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Flier",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Frenzy",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Frightening",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Grudge-born Fury",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Hardy",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Hedge Magic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Hoverer",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Keen Senses",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Lesser Magic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Lightning Parry",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Lightning Reflexes",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Linguistics",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Luck",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Marksman",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Master Gunner",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Master Orator",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Meditation",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Menacing",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Mighty Missile",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Mighty Shot",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Mimic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Natural Weapons",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Night Vision",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Orientation",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Petty Magic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Public Speaking",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Quick Draw",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Rapid Reload",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Resistance to Chaos",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Resistance to Disease",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Resistance to Magic",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Resistance to Poison",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Rover",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Savvy",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Schemer",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Seasoned Traveller",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Sharpshooter",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Sixth Sense",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Specialist Weapon Group: null",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Stout-hearted",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Street Fighting",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Streetwise",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Strike Mighty Blow",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Strike to Injure",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Strike to Stun",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Strong-minded",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Sturdy",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Suave",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Sure Shot",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Surgery",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Super Numerate",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Swashbuckler",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Terryfying",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Trick Riding",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Tunnel Rat",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Undead",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Unsettling",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Very Resilient",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Very Strong",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Warrior Born",
                Description = ""
            });
            context.Talents.Add(new Talent()
            {
                Name = "Wrestling",
                Description = ""
            });

        }
    }
}
