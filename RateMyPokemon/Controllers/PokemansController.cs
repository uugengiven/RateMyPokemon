using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RateMyPokemon.Models;

namespace RateMyPokemon.Controllers
{
    public class PokemansController : Controller
    {
        private PokemonDbContext db = new PokemonDbContext();

        // GET: Pokemans
        public ActionResult Index()
        {
            return View(db.Pokemans.ToList());
        }

        // GET: Pokemans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemans.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // GET: Pokemans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokemans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Rating,Picture")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Pokemans.Add(pokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }

        // GET: Pokemans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemans.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Rating,Picture")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        // GET: Pokemans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokemon pokemon = db.Pokemans.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokemon pokemon = db.Pokemans.Find(id);
            db.Pokemans.Remove(pokemon);
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
