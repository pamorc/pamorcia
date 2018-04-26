using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WHF.Models
{
    public class WHFContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WHFContext() : base("name=WHFContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("WHF");
            modelBuilder.Entity<Player>().HasRequired(m => m.Attributes).WithRequiredPrincipal(m => m.Player);
            modelBuilder.Entity<Player>().HasRequired(m => m.Armor).WithRequiredPrincipal(m => m.Player);
            modelBuilder.Entity<Player>().HasRequired(m => m.Game).WithMany(m => m.Players);
        }

        public System.Data.Entity.DbSet<WHF.Models.Player> Players { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.Armor> Armors { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.Attributes> Attributes { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.Skill> Skills { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.Talent> Talents { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.PlayerSkill> PlayerSkills { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.PlayerTalent> PlayerTalents { get; set; }
        public System.Data.Entity.DbSet<WHF.Models.Game> Games { get; set; }
    }
}
