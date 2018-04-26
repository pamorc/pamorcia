using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WHF.Models;

namespace WHF.Controllers
{
    public class GamesController : Controller
    {
        private WHFContext db = new WHFContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult PlayerInCombat(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Player player = db.Players.Find(id);
        //    if (player == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(player);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PlayerInCombat([Bind(Include = "PlayerID,Roll,Dmg")] Player player)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(player).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(player);
        //}


        public ActionResult Play(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            // load players
            List<Player> players = db.Players.Where(p => p.GameID == id).ToList();
            // load attributes
            foreach (Player player in players)
            {
                player.Attributes = db.Attributes.Find(player.AttributesID);
                player.Attributes.display = DisplayType.Short;
                player.attack = new Attack();
            }
            return View(players);
        }

        //public ActionResult Hit(int? id, int? roll, int? dmg)
        //{
        //    //if (player == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //if (ModelState.IsValid)
        //    //{

        //    //}
        //    Player player = db.Players.Find(id);
        //    if (player == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        //    // add damage

        //        //    db.Entry(player).State = EntityState.Modified;
        //        //    db.SaveChanges();
        //        return Content(id + " " + roll + " " + dmg);
        //        //return RedirectToAction("Play", player.GameID);
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost, ActionName("Hit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Play([Bind(Include = "PlayerID,attack")] Player player)
        //{
        //    if (player == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    //Player player = db.Players.Find(attack.PlayerID);
        //    if (player == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // add damage

        //        db.Entry(player).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Play", player.GameID);
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult PlayerHit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            player.Attributes = db.Attributes.Find(player.AttributesID);
            player.Attributes.display = DisplayType.Short;
            Hit hit = new Hit();
            hit.PlayerID = player.PlayerID;
            hit.Player = player;

            return View(hit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlayerHit([Bind(Include = "GameID,PlayerID,Roll,Damage,DirectDmg,ArmourPiercing,SureShot")] Hit hit)
        {
            if (ModelState.IsValid)
            {
                Player player = db.Players.Find(hit.PlayerID);
                player.Attributes = db.Attributes.Find(player.AttributesID);
                // check for direct damage
                if (hit.DirectDmg > 0)
                {
                    if (player.Attributes.Wound - hit.DirectDmg > player.Attributes.MaxWound)
                    {
                        player.Attributes.Wound = player.Attributes.MaxWound;
                    }
                    else
                    {
                        player.Attributes.Wound -= hit.DirectDmg;
                    }
                    return RedirectToAction("Play", new { id = player.GameID });
                }
                // check for armour modifiers
                int armourvalue = GetArmorValue(player, hit.Roll);
                if (armourvalue > 0 && hit.ArmourPiercing)
                {
                    armourvalue -= 1;
                }
                if (armourvalue > 0 && hit.SureShot)
                {
                    armourvalue -= 1;
                }
                // check for damage
                int toughtnessbonus = (int)(player.Attributes.Toughness / 10);
                int defence = armourvalue + toughtnessbonus;
                if (hit.Damage > defence)
                {
                    player.Attributes.Wound -= hit.Damage - defence;
                }
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                //return Play(player.GameID);
                return RedirectToAction("Play", new { id = player.GameID });
            }

            // reload player

            hit.Player = db.Players.Find(hit.PlayerID);
            hit.Player.Attributes = db.Attributes.Find(hit.Player.AttributesID);
            hit.Player.Attributes.display = DisplayType.Short;
            hit.Roll = 0;
            hit.Damage = 0;

            return View(hit);
        }

        private int GetArmorValue(Player player, int roll)
        {
            player.Armor = db.Armors.Find(player.ArmorID);
            
            if (roll >= 1 && roll <= 15)
            {
                return player.Armor.Head;
            }
            else if (roll >= 16 && roll <= 35)
            {
                return player.Armor.RightArm;
            }
            else if (roll >= 36 && roll <= 55)
            {
                return player.Armor.LeftArm;
            }
            else if (roll >= 56 && roll <= 80)
            {
                return player.Armor.Body;
            }
            else if (roll >= 81 && roll <= 90)
            {
                return player.Armor.RightLeg;
            }
            else if (roll >= 91 && roll <= 100)
            {
                return player.Armor.LeftLeg;
            }
            else
            {
                return 0;
            }
        }
    }
}
