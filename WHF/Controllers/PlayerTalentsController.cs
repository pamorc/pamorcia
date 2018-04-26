using Newtonsoft.Json;
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
    public class PlayerTalentsController : Controller
    {
        private WHFContext db = new WHFContext();

        // GET: PlayerTalents
        public ActionResult Index(int? id)
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
            ViewBag.PlayerID = player.PlayerID;
            var playerTalents = db.PlayerTalents.OrderBy(o => o.Talent.Name).Where(p => p.PlayerID == player.PlayerID).Include(p => p.Player).Include(p => p.Talent);
            return View(playerTalents.ToList());
        }

        // GET: PlayerTalents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTalent playerTalent = db.PlayerTalents.Find(id);
            if (playerTalent == null)
            {
                return HttpNotFound();
            }
            return View(playerTalent);
        }

        // GET: PlayerTalents/Create
        public ActionResult Add(int? id)
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

            ViewBag.Player = player;
            ViewBag.Talents = db.Talents.OrderBy(o => o.Name).ToList();
            ViewBag.TalentList = JsonConvert.SerializeObject(db.Talents.OrderBy(o => o.Name).ToList());
            PlayerTalent talent = new PlayerTalent();
            talent.PlayerID = player.PlayerID;
            return View(talent);
        }

        // POST: PlayerTalents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "PlayerTalentID,PlayerID,TalentID")] PlayerTalent playerTalent)
        {
            if (ModelState.IsValid)
            {
                db.PlayerTalents.Add(playerTalent);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = playerTalent.PlayerID });
            }

            int? id = playerTalent.PlayerID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            ViewBag.Player = player;
            ViewBag.Talents = db.Talents.OrderBy(o => o.Name).ToList();
            ViewBag.TalentList = JsonConvert.SerializeObject(db.Talents.OrderBy(o => o.Name).ToList());
            PlayerTalent talent = new PlayerTalent();
            talent.PlayerID = player.PlayerID;
            return View(talent);
        }

        // GET: PlayerTalents/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PlayerTalent playerTalent = db.PlayerTalents.Find(id);
        //    if (playerTalent == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerTalent.PlayerID);
        //    ViewBag.TalentID = new SelectList(db.Talents, "TalentID", "Name", playerTalent.TalentID);
        //    return View(playerTalent);
        //}

        //// POST: PlayerTalents/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PlayerTalentID,PlayerID,TalentID")] PlayerTalent playerTalent)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(playerTalent).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerTalent.PlayerID);
        //    ViewBag.TalentID = new SelectList(db.Talents, "TalentID", "Name", playerTalent.TalentID);
        //    return View(playerTalent);
        //}

        // GET: PlayerTalents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerTalent playerTalent = db.PlayerTalents.Find(id);
            if (playerTalent == null)
            {
                return HttpNotFound();
            }
            return View(playerTalent);
        }

        // POST: PlayerTalents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerTalent playerTalent = db.PlayerTalents.Find(id);
            db.PlayerTalents.Remove(playerTalent);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = playerTalent.PlayerID });
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
