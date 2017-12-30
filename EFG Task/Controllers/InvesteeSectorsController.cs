using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFG_Task.Models;

namespace EFG_Task.Controllers
{
    public class InvesteeSectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvesteeSectors
        public ActionResult Index()
        {
            return View(db.InvesteeSectors.ToList());
        }

        // GET: InvesteeSectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvesteeSector investeeSector = db.InvesteeSectors.Find(id);
            if (investeeSector == null)
            {
                return HttpNotFound();
            }
            return View(investeeSector);
        }

        // GET: InvesteeSectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvesteeSectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "investeeSectorID,interestedSector,timeSector")] InvesteeSector investeeSector)
        {
            if (ModelState.IsValid)
            {
                db.InvesteeSectors.Add(investeeSector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investeeSector);
        }

        // GET: InvesteeSectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvesteeSector investeeSector = db.InvesteeSectors.Find(id);
            if (investeeSector == null)
            {
                return HttpNotFound();
            }
            return View(investeeSector);
        }

        // POST: InvesteeSectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "investeeSectorID,interestedSector,timeSector")] InvesteeSector investeeSector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investeeSector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investeeSector);
        }

        // GET: InvesteeSectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvesteeSector investeeSector = db.InvesteeSectors.Find(id);
            if (investeeSector == null)
            {
                return HttpNotFound();
            }
            return View(investeeSector);
        }

        // POST: InvesteeSectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvesteeSector investeeSector = db.InvesteeSectors.Find(id);
            db.InvesteeSectors.Remove(investeeSector);
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
