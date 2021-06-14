using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Producent.Models;

namespace Producent.Controllers
{
    public class IndeksController : Controller
    {
        private ProducentEntities db = new ProducentEntities();

        // GET: Indeks
        public ActionResult Index()
        {
            var indeks = db.Indeks.Include(i => i.JednostkaMiary).Include(i => i.RodzajIndeksu);
            return View(indeks.ToList());
        }

        // GET: Indeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indeks indeks = db.Indeks.Find(id);
            if (indeks == null)
            {
                return HttpNotFound();
            }
            return View(indeks);
        }

        // GET: Indeks/Create
        public ActionResult Create()
        {
            ViewBag.JednostkaMiaryId = new SelectList(db.JednostkaMiary, "Id", "Kod");
            ViewBag.RodzajIndeksuId = new SelectList(db.RodzajIndeksu, "Id", "Kod");
            return View();
        }

        // POST: Indeks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kod,Nazwa,RodzajIndeksuId,JednostkaMiaryId,CenaZakupu,CenaSprzedazy,Ciężar,CzyAktywny,CzyTechnologia,IndeksDostawcy,Opis,OpisDostawcy,KodKreskowy,LiczbaDniDostawy,StanMin,StanMax")] Indeks indeks)
        {
            if (ModelState.IsValid)
            {
                db.Indeks.Add(indeks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JednostkaMiaryId = new SelectList(db.JednostkaMiary, "Id", "Kod", indeks.JednostkaMiaryId);
            ViewBag.RodzajIndeksuId = new SelectList(db.RodzajIndeksu, "Id", "Kod", indeks.RodzajIndeksuId);
            return View(indeks);
        }

        // GET: Indeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indeks indeks = db.Indeks.Find(id);
            if (indeks == null)
            {
                return HttpNotFound();
            }
            ViewBag.JednostkaMiaryId = new SelectList(db.JednostkaMiary, "Id", "Kod", indeks.JednostkaMiaryId);
            ViewBag.RodzajIndeksuId = new SelectList(db.RodzajIndeksu, "Id", "Kod", indeks.RodzajIndeksuId);
            return View(indeks);
        }

        // POST: Indeks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kod,Nazwa,RodzajIndeksuId,JednostkaMiaryId,CenaZakupu,CenaSprzedazy,Ciężar,CzyAktywny,CzyTechnologia,IndeksDostawcy,Opis,OpisDostawcy,KodKreskowy,LiczbaDniDostawy,StanMin,StanMax")] Indeks indeks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indeks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JednostkaMiaryId = new SelectList(db.JednostkaMiary, "Id", "Kod", indeks.JednostkaMiaryId);
            ViewBag.RodzajIndeksuId = new SelectList(db.RodzajIndeksu, "Id", "Kod", indeks.RodzajIndeksuId);
            return View(indeks);
        }

        // GET: Indeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indeks indeks = db.Indeks.Find(id);
            if (indeks == null)
            {
                return HttpNotFound();
            }
            return View(indeks);
        }

        // POST: Indeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indeks indeks = db.Indeks.Find(id);
            db.Indeks.Remove(indeks);
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
