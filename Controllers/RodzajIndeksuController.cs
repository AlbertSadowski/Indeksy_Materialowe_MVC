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
    public class RodzajIndeksuController : Controller
    {
        private ProducentEntities db = new ProducentEntities();

        // GET: RodzajIndeksu
        public ActionResult Index()
        {
            return View(db.RodzajIndeksu.ToList());
        }

        // GET: RodzajIndeksu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RodzajIndeksu rodzajIndeksu = db.RodzajIndeksu.Find(id);
            if (rodzajIndeksu == null)
            {
                return HttpNotFound();
            }
            return View(rodzajIndeksu);
        }

        // GET: RodzajIndeksu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RodzajIndeksu/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kod,Nazwa")] RodzajIndeksu rodzajIndeksu)
        {
            if (ModelState.IsValid)
            {
                db.RodzajIndeksu.Add(rodzajIndeksu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rodzajIndeksu);
        }

        // GET: RodzajIndeksu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RodzajIndeksu rodzajIndeksu = db.RodzajIndeksu.Find(id);
            if (rodzajIndeksu == null)
            {
                return HttpNotFound();
            }
            return View(rodzajIndeksu);
        }

        // POST: RodzajIndeksu/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kod,Nazwa")] RodzajIndeksu rodzajIndeksu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rodzajIndeksu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rodzajIndeksu);
        }

        // GET: RodzajIndeksu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RodzajIndeksu rodzajIndeksu = db.RodzajIndeksu.Find(id);
            if (rodzajIndeksu == null)
            {
                return HttpNotFound();
            }
            return View(rodzajIndeksu);
        }

        // POST: RodzajIndeksu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RodzajIndeksu rodzajIndeksu = db.RodzajIndeksu.Find(id);
            db.RodzajIndeksu.Remove(rodzajIndeksu);
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
