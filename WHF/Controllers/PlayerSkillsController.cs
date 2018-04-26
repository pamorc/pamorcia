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
    public class PlayerSkillsController : Controller
    {
        private WHFContext db = new WHFContext();

        // GET: PlayerSkills
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
            var playerSkills = db.PlayerSkills.OrderBy(o => o.Skill.Name).Where(p => p.PlayerID == player.PlayerID).Include(p => p.Player).Include(p => p.Skill);
            return View(playerSkills.ToList());
        }

        // GET: PlayerSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerSkill playerSkill = db.PlayerSkills.Find(id);
            if (playerSkill == null)
            {
                return HttpNotFound();
            }
            return View(playerSkill);
        }

        // GET: PlayerSkills/Create
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
            ViewBag.Skills = db.Skills.OrderBy(o => o.Name).ToList();
            ViewBag.SkillList = JsonConvert.SerializeObject(db.Skills.OrderBy(o => o.Name).ToList());
            PlayerSkill skill = new PlayerSkill();
            skill.PlayerID = player.PlayerID;
            return View(skill);
        }

        // POST: PlayerSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "PlayerSkillID,PlayerID,SkillID")] PlayerSkill playerSkill)
        {
            if (ModelState.IsValid)
            {
                db.PlayerSkills.Add(playerSkill);
                db.SaveChanges();
                return RedirectToAction("Index",  new { id = playerSkill.PlayerID });
            }

            int? id = playerSkill.PlayerID;

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
            ViewBag.Skills = db.Skills.OrderBy(o => o.Name).ToList();
            ViewBag.SkillList = JsonConvert.SerializeObject(db.Skills.OrderBy(o => o.Name).ToList());
            PlayerSkill skill = new PlayerSkill();
            skill.PlayerID = player.PlayerID;
            return View(skill);
        }

        //// GET: PlayerSkills/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PlayerSkill playerSkill = db.PlayerSkills.Find(id);
        //    if (playerSkill == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerSkill.PlayerID);
        //    ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "Name", playerSkill.SkillID);
        //    return View(playerSkill);
        //}

        //// POST: PlayerSkills/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PlayerSkillID,PlayerID,SkillID,Attribute,SkillValue")] PlayerSkill playerSkill)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(playerSkill).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerSkill.PlayerID);
        //    ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "Name", playerSkill.SkillID);
        //    return View(playerSkill);
        //}

        // GET: PlayerSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerSkill playerSkill = db.PlayerSkills.Find(id);
            if (playerSkill == null)
            {
                return HttpNotFound();
            }
            return View(playerSkill);
        }

        // POST: PlayerSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerSkill playerSkill = db.PlayerSkills.Find(id);
            db.PlayerSkills.Remove(playerSkill);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = playerSkill.PlayerID });
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
