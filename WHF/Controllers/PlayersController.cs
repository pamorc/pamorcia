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
    public class PlayersController : Controller
    {
        private WHFContext db = new WHFContext();

        // GET: Players
        public ActionResult Index()
        {
            return View(db.Players.ToList());
        }

        private List<PlayerSkill> GetSkills(int playerid)
        {
            return db.PlayerSkills.Where(p => p.PlayerID == playerid).ToList();
        }

        private List<PlayerTalent> GetTalents(int playerid)
        {
            return db.PlayerTalents.Where(p => p.PlayerID == playerid).ToList();
        }

        public ActionResult PlayerAtts()
        {
            // load players
            var players = db.Players.ToList();
            // load atributes and armors
            try
            {
                foreach (Player player in players)
                {
                    player.Attributes = db.Attributes.Find(player.AttributesID);
                    player.Attributes.display = DisplayType.Short;
                    player.Armor = db.Armors.Find(player.ArmorID);
                }
                return View(players);
            }
            catch
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult DisplaySkills(int? id)
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
            return RedirectToAction("Index", "PlayerSkills", new { id = player.PlayerID });
        }

        public ActionResult DisplayTalents(int? id)
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
            return RedirectToAction("Index", "PlayerTalents", new { id = player.PlayerID });
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
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
            player.Game = db.Games.Find(player.GameID);
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            Player player = new Player();
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Name");
            return View(player);
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,Name,GameID")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Name", player.GameID);
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Games = db.Games.ToList();
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,Name,AttributesID,ArmorID")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        public ActionResult EditAttributes(int? id)
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
            Attributes att = db.Attributes.Find(player.AttributesID);
            if (att == null)
            {
                att = new Attributes();
                att.PlayerID = (int)id;
            }
            return View(att);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAttributes(Attributes att)
        {
            if (ModelState.IsValid)
            {
                if (att.AttributesID > 0)
                {
                    db.Entry(att).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Player player = db.Players.Find(att.PlayerID);
                    player.Attributes = db.Attributes.Add(att);
                    db.SaveChanges();
                    player.AttributesID = att.AttributesID;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(att);
        }

        public ActionResult EditArmor(int? id)
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
            Armor armor = db.Armors.Find(player.ArmorID);
            if (armor == null)
            {
                armor = new Armor();
                armor.PlayerID = (int)id;
            }
            return View(armor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArmor(Armor armor)
        {
            if (ModelState.IsValid)
            {
                if (armor.ArmorID > 0)
                {
                    db.Entry(armor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Player player = db.Players.Find(armor.PlayerID);
                    player.Armor = db.Armors.Add(armor);
                    db.SaveChanges();
                    player.ArmorID = armor.ArmorID;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(armor);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
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
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
    }
}
