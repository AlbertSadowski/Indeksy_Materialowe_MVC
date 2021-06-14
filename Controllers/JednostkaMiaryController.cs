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
    public class JednostkaMiaryController : Controller
    {
        private ProducentEntities db = new ProducentEntities();

        // GET: JednostkaMiary
        public ActionResult Index()
        {
            return View(db.JednostkaMiary.ToList());
        }

        // GET: JednostkaMiary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JednostkaMiary jednostkaMiary = db.JednostkaMiary.Find(id);
            if (jednostkaMiary == null)
            {
                return HttpNotFound();
            }
            return View(jednostkaMiary);
        }

        // GET: JednostkaMiary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JednostkaMiary/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kod,Nazwa")] JednostkaMiary jednostkaMiary)
        {
            if (ModelState.IsValid)
            {
                db.JednostkaMiary.Add(jednostkaMiary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jednostkaMiary);
        }

        // GET: JednostkaMiary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JednostkaMiary jednostkaMiary = db.JednostkaMiary.Find(id);
            if (jednostkaMiary == null)
            {
                return HttpNotFound();
            }
            return View(jednostkaMiary);
        }

        // POST: JednostkaMiary/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kod,Nazwa")] JednostkaMiary jednostkaMiary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jednostkaMiary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jednostkaMiary);
        }

        // GET: JednostkaMiary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JednostkaMiary jednostkaMiary = db.JednostkaMiary.Find(id);
            if (jednostkaMiary == null)
            {
                return HttpNotFound();
            }
            return View(jednostkaMiary);
        }

        // POST: JednostkaMiary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JednostkaMiary jednostkaMiary = db.JednostkaMiary.Find(id);
            db.JednostkaMiary.Remove(jednostkaMiary);
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
